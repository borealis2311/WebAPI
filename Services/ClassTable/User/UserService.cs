using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassTable.User
{
    public partial class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_UserAccount> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_UserAccount>().GetAll();
        }
        public SAM_UserAccount GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_UserAccount>().GetById(id);
        }
        public async Task<int> Addsync(SAM_UserAccount user)
        {
            ValidationCreatedUser(user);
            ValidationUserName(user);
            user.IsBlocked = false;
            user.IsActivated = !user.IsBlocked;
            user.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_UserAccount>().AddAsync(user);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Update(SAM_UserAccount user)
        {
            user.UpdatedDate = DateTime.Now;
            _unitOfWork.RepositoryAsync<SAM_UserAccount>().Update(user);
            return _unitOfWork.Save();
        }
        public int Remove(SAM_UserAccount user)
        {
            _unitOfWork.RepositoryAsync<SAM_UserAccount>().Remove(user);
            return _unitOfWork.Save();
        }
        private void ValidationCreatedUser(SAM_UserAccount user)
        {
            var customer = _unitOfWork.RepositoryAsync<MD_Customer>().Find(x => x.CustomerID == user.CustomerID.Value).FirstOrDefault();
            if (customer == null)
                throw new Exception("No customer in the system");

            var u = _unitOfWork.RepositoryAsync<SAM_UserAccount>().Find(x => x.CustomerID == user.CustomerID.Value).FirstOrDefault();
            if (u != null)
                throw new Exception("Customer has account already");
        }
        private void ValidationUserName(SAM_UserAccount user)
        {
            var exist = _unitOfWork.RepositoryAsync<SAM_UserAccount>().Find(x => x.AccountName == user.AccountName).FirstOrDefault();
            if (exist != null)
                throw new Exception("Exist UserAccount in the system");
        }

        public List<UserDto> GetInforById(int Accountid)
        {
            var result = (from a in _unitOfWork.RepositoryAsync<SAM_UserAccount>().Queryable()
                          join ur in _unitOfWork.RepositoryAsync<SAM_UserInRole>().Queryable() on a.AccountID equals ur.AccountID
                          join r in _unitOfWork.RepositoryAsync<SAM_Role>().Queryable() on ur.RoleID equals r.RoleID
                          join fr in _unitOfWork.RepositoryAsync<SAM_FuncInRole>().Queryable() on r.RoleID equals fr.RoleID
                          join f in _unitOfWork.RepositoryAsync<SAM_Function>().Queryable() on fr.FuncID equals f.FuncID
                          where a.AccountID == Accountid && a.IsBlocked == false && ur.IsBlocked == false && r.IsBlocked == false && fr.IsBlocked == false && f.IsBlocked == false
                          select new UserDto
                          {
                              RoleName = r.RoleName,
                              RoleNotes = r.RoleNotes,
                              RoleCode = r.RoleCode,
                              FuncCode = f.FuncCode,
                              FuncDesc = f.FuncDesc,
                              URL = f.URL,
                          }).ToList();
            return result;
        }
    }
}
