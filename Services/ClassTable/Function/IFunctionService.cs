using Domain.Entities.TableClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.Function
{
    public interface IFunctionService
    {
        IEnumerable<SAM_Function> GetAll();
        SAM_Function GetById(int id);
        Task<int> Addsync(SAM_Function user);
        int Update(SAM_Function user);
        int Remove(SAM_Function user);
    }
}
