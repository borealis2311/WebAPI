using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.TableClass;
using Services.Model.Add;
using Services.ClassTable.UserInRole;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInRoleController : ControllerBase
    {
        private readonly IUserInRoleService _userinroleService;
        public UserInRoleController(IUserInRoleService userinroleService)
        {
            _userinroleService = userinroleService;
        }
        //GetAllUser
        [HttpGet("GetAllUserInRole")]
        public IEnumerable<SAM_UserInRole> GetAllUser()
        {
            return _userinroleService.GetAll();
        }
        //AddNewUser
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddUserInRole(UserInRoleRequest Uir)
        {
            try
            {
                var plus = new SAM_UserInRole()
                {
                    RoleID = Uir.Roleid,
                    AccountID = Uir.Accountid
                };
                await _userinroleService.Addsync(plus);
                return Ok("Add UserInRole Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetUserInRoleByID")]
        public async Task<IActionResult> GetUserInRoleById([FromQuery] int id)
        {
            try
            {
                var gt = _userinroleService.GetById(id);
                if (gt == null)
                    return NotFound("Blank id empty or invalid id");
                return Ok(gt);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteUser
        [HttpDelete("DeleteUserInRole")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _userinroleService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _userinroleService.Remove(dlt);
                return Ok("Deleted UserInRole Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
