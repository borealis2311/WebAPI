using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.TableClass;
using Services.Dto;

namespace Services.ClassTable.Role
{
    public partial class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_Role> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_Role>().GetAll();
        }
        public SAM_Role GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_Role>().GetById(id);
        }
        public async Task<int> Addsync(SAM_Role role)
        {
            ValidationCreatedCustomer(role);
            role.IsBlocked = false;
            role.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_Role>().AddAsync(role);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Update(SAM_Role role)
        {
            role.UpdatedDate = DateTime.Now;
            _unitOfWork.RepositoryAsync<SAM_Role>().Update(role);
            return _unitOfWork.Save();
        }
        public int Remove(SAM_Role role)
        {
            _unitOfWork.RepositoryAsync<SAM_Role>().Remove(role);
            return _unitOfWork.Save();
        }
        private void ValidationCreatedCustomer(SAM_Role role)
        {
            var exist = _unitOfWork.RepositoryAsync<SAM_Role>().Find(x => x.RoleCode == role.RoleCode).FirstOrDefault();
            if (exist != null)
                throw new Exception("Exist role in the system");
        }
        public List<UserInRoleDto> GetUserInRoleById(int roleId)
        {
            var result = (from r in _unitOfWork.RepositoryAsync<SAM_Role>().Queryable()
                          join ur in _unitOfWork.RepositoryAsync<SAM_UserInRole>().Queryable() on r.RoleID equals ur.RoleID
                          join u in _unitOfWork.RepositoryAsync<SAM_UserAccount>().Queryable() on ur.AccountID equals u.AccountID
                          join c in _unitOfWork.RepositoryAsync<MD_Customer>().Queryable() on u.CustomerID equals c.CustomerID
                          where r.RoleID == roleId && r.IsBlocked == false && ur.IsBlocked == false
                          select new UserInRoleDto
                          {
                              CustomerCode = c.CustomerCode,
                              FullName = c.FullName,
                              TaxCode = c.TaxCode,
                              Address = c.Address,
                              AccountName = u.AccountName,
                              AccPwd = u.AccPwd,
                              AccountEmail = u.AccountEmail,
                              RecoveryEmail = u.RecoveryEmail
                          }).ToList();

            return result;

        }
        public List<FuncInRoleDto> GetFuncInRoleById(int roleId)
        {
            var result = (from r in _unitOfWork.RepositoryAsync<SAM_Role>().Queryable()
                          join fr in _unitOfWork.RepositoryAsync<SAM_FuncInRole>().Queryable() on r.RoleID equals fr.RoleID
                          join f in _unitOfWork.RepositoryAsync<SAM_Function>().Queryable() on fr.FuncID equals f.FuncID
                          join m in _unitOfWork.RepositoryAsync<SAM_Module>().Queryable() on f.ModuleID equals m.ModuleID
                          where r.RoleID == roleId && r.IsBlocked == false && fr.IsBlocked == false
                          select new FuncInRoleDto
                          {
                              ModuleCode = m.ModuleCode,
                              ModuleDesc = m.ModuleDesc,
                              Icon = m.Icon,
                              FuncCode = f.FuncCode,
                              FuncDesc = f.FuncDesc,
                              Url = f.URL
                          }).ToList();
            return result;
        }
    }
}
