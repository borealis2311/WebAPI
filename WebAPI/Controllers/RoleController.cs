using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Mvc;
using Services.ClassTable.Role;
using Services.Model.Add;
using Services.Model.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        //GetAllUser
        [HttpGet("GetAllRole")]
        public IEnumerable<SAM_Role> GetAllCustomer()
        {
            return _roleService.GetAll();
        }
        //AddNewUser
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleRequest role)
        {
            try
            {
                var mc = new SAM_Role()
                {
                    RoleName = role.Rolename,
                    RoleNotes = role.Rolenotes,
                    RoleCode = role.Rolecode
                };
                await _roleService.Addsync(mc);
                return Ok("Add Role Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetRoleByID")]
        public async Task<IActionResult> GetRoleById([FromQuery] int id)
        {
            try
            {
                var gt = _roleService.GetById(id);
                if (gt == null)
                    return NotFound("Blank id empty or invalid id");
                return Ok(gt);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //EditUser
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] RoleUpdateRequest role)
        {
            try
            {
                var ed = _roleService.GetById(id);
                if (ed == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }

                ed.RoleName = role.Rolename;
                ed.RoleNotes = role.Rolenotes;
                ed.IsBlocked = role.Isblocked;
                _roleService.Update(ed);
                return Ok("Edited Role Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteUser
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _roleService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _roleService.Remove(dlt);
                return Ok("Deleted Role Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetUserByRoleID")]
        public async Task<IActionResult> GetUserByRoleId([FromQuery] int id)
        {
            return Ok(_roleService.GetUserInRoleById(id));
        }
        [HttpGet("GetFuncByRoleID")]
        public async Task<IActionResult> GetFuncByRoleId([FromQuery] int id)
        {
            return Ok(_roleService.GetFuncInRoleById(id));
        }
    }
}
