using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Services.ClassTable.FuncInRole
{
    public partial class FuncInRoleService : IFuncInRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FuncInRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_FuncInRole> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_FuncInRole>().GetAll();
        }
        public SAM_FuncInRole GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_FuncInRole>().GetById(id);
        }
        public async Task<int> Addsync(SAM_FuncInRole Fir)
        {
            ValidationCreated(Fir);
            Fir.IsBlocked = false;
            Fir.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_FuncInRole>().AddAsync(Fir);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Remove(SAM_FuncInRole Fir)
        {
            _unitOfWork.RepositoryAsync<SAM_FuncInRole>().Remove(Fir);
            return _unitOfWork.Save();
        }
        private void ValidationCreated(SAM_FuncInRole Fir)
        {
            var y = _unitOfWork.RepositoryAsync<SAM_Function>().Find(x => x.FuncID == Fir.FuncID.Value).FirstOrDefault();
            if (y == null)
                throw new Exception("No funcid in the system");

            var z = _unitOfWork.RepositoryAsync<SAM_Role>().Find(x => x.RoleID == Fir.RoleID.Value).FirstOrDefault();
            if (z == null)
                throw new Exception("No roleid in the system");

            var u = _unitOfWork.RepositoryAsync<SAM_FuncInRole>().Find(x => x.FuncID == Fir.FuncID.Value && x.RoleID == Fir.RoleID.Value).FirstOrDefault();
            if (u != null)
                throw new Exception("Available");
        }
    }
}
