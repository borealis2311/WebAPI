using Domain.Entities.TableClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.UserInRole
{
    public interface IUserInRoleService
    {
        IEnumerable<SAM_UserInRole> GetAll();
        SAM_UserInRole GetById(int id);
        Task<int> Addsync(SAM_UserInRole Fir);
        int Remove(SAM_UserInRole Fir);
    }
}
