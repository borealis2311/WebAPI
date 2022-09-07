using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassTable.Function
{
    public partial class FunctionService : IFunctionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FunctionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_Function> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_Function>().GetAll();
        }
        public SAM_Function GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_Function>().GetById(id);
        }
        public async Task<int> Addsync(SAM_Function func)
        {
            ValidationCreatedUser(func);
            ValidationUserName(func);
            func.IsBlocked = false;
            func.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_Function>().AddAsync(func);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Update(SAM_Function func)
        {
            func.UpdatedDate = DateTime.Now;
            _unitOfWork.RepositoryAsync<SAM_Function>().Update(func);
            return _unitOfWork.Save();
        }
        public int Remove(SAM_Function func)
        {
            _unitOfWork.RepositoryAsync<SAM_Function>().Remove(func);
            return _unitOfWork.Save();
        }
        private void ValidationCreatedUser(SAM_Function func)
        {
            var customer = _unitOfWork.RepositoryAsync<SAM_Module>().Find(x => x.ModuleID == func.ModuleID.Value).FirstOrDefault();
            if (customer == null)
                throw new Exception("No module in the system");

            var u = _unitOfWork.RepositoryAsync<SAM_Function>().Find(x => x.ModuleID == func.ModuleID.Value).FirstOrDefault();
            if (u != null)
                throw new Exception("Module available");
        }
        private void ValidationUserName(SAM_Function func)
        {
            var exist = _unitOfWork.RepositoryAsync<SAM_Function>().Find(x => x.FuncCode == func.FuncCode).FirstOrDefault();
            if (exist != null)
                throw new Exception("Exist function code in the system");
        }
    }
}
