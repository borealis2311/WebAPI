using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassTable.UserInRole
{
    public partial class UserInRoleService : IUserInRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserInRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_UserInRole> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_UserInRole>().GetAll();
        }
        public SAM_UserInRole GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_UserInRole>().GetById(id);
        }
        public async Task<int> Addsync(SAM_UserInRole Uir)
        {
            ValidationCreated(Uir);
            Uir.IsBlocked = false;
            Uir.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_UserInRole>().AddAsync(Uir);
            return await _unitOfWork.SaveChangesAsync();
        }

        public int Remove(SAM_UserInRole Uir)
        {
            _unitOfWork.RepositoryAsync<SAM_UserInRole>().Remove(Uir);
            return _unitOfWork.Save();
        }
        private void ValidationCreated(SAM_UserInRole Uir)
        {
            var y = _unitOfWork.RepositoryAsync<SAM_UserAccount>().Find(x => x.AccountID == Uir.AccountID.Value).FirstOrDefault();
            if (y == null)
                throw new Exception("No accountid in the system");

            var z = _unitOfWork.RepositoryAsync<SAM_Role>().Find(x => x.RoleID == Uir.RoleID.Value).FirstOrDefault();
            if (z == null)
                throw new Exception("No roleid in the system");

            var u = _unitOfWork.RepositoryAsync<SAM_UserInRole>().Find(x => x.AccountID == Uir.AccountID.Value && x.RoleID == Uir.RoleID.Value).FirstOrDefault();
            if (u != null)
                throw new Exception("Available");
        }
    }
}
