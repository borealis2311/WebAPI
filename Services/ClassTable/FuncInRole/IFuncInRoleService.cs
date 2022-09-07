using Domain.Entities.TableClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.FuncInRole
{
    public interface IFuncInRoleService
    {
        IEnumerable<SAM_FuncInRole> GetAll();
        SAM_FuncInRole GetById(int id);
        Task<int> Addsync(SAM_FuncInRole Fir);
        int Remove(SAM_FuncInRole Fir);
    }
}
