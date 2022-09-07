using Domain.Entities.TableClass;
using Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.User
{
    public interface IUserService
    {
        IEnumerable<SAM_UserAccount> GetAll();
        SAM_UserAccount GetById(int id);
        Task<int> Addsync(SAM_UserAccount user);
        int Update(SAM_UserAccount user);
        int Remove(SAM_UserAccount user);
        List<UserDto> GetInforById(int Accountid);
    }
}
