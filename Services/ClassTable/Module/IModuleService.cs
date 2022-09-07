using Domain.Entities.TableClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.Module
{
    public interface IModuleService
    {
        IEnumerable<SAM_Module> GetAll();
        SAM_Module GetById(int id);
        Task<int> Addsync(SAM_Module user);
        int Update(SAM_Module user);
        int Remove(SAM_Module user);
    }
}
