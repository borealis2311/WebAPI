using DataAccessEF.Interfaces;
using Domain.Entities.TableClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassTable.Module
{
    public partial class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SAM_Module> GetAll()
        {
            return _unitOfWork.RepositoryAsync<SAM_Module>().GetAll();
        }
        public SAM_Module GetById(int id)
        {
            return _unitOfWork.RepositoryAsync<SAM_Module>().GetById(id);
        }
        public async Task<int> Addsync(SAM_Module module)
        {
            ValidationUserName(module);
            module.IsBlocked = false;
            module.CreatedDate = DateTime.Now;
            await _unitOfWork.RepositoryAsync<SAM_Module>().AddAsync(module);
            return await _unitOfWork.SaveChangesAsync();
        }
        public int Update(SAM_Module module)
        {
            module.UpdatedDate = DateTime.Now;
            _unitOfWork.RepositoryAsync<SAM_Module>().Update(module);
            return _unitOfWork.Save();
        }
        public int Remove(SAM_Module module)
        {
            _unitOfWork.RepositoryAsync<SAM_Module>().Remove(module);
            return _unitOfWork.Save();
        }
        private void ValidationUserName(SAM_Module module)
        {
            var exist = _unitOfWork.RepositoryAsync<SAM_Module>().Find(x => x.ModuleCode == module.ModuleCode).FirstOrDefault();
            if (exist != null)
                throw new Exception("Exist module in the system");
        }
    }
}
