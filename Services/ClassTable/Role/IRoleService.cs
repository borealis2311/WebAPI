using Domain.Entities.TableClass;
using Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ClassTable.Role
{
    public interface IRoleService
    {
        IEnumerable<SAM_Role> GetAll();
        SAM_Role GetById(int id);
        Task<int> Addsync(SAM_Role role);
        int Update(SAM_Role role);
        int Remove(SAM_Role role);
        List<UserInRoleDto> GetUserInRoleById(int roleId);
        List<FuncInRoleDto> GetFuncInRoleById(int roleId);
    }
}
