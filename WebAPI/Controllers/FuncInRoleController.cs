using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.TableClass;
using Services.Model.Add;
using Services.ClassTable.FuncInRole;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncInRoleController : ControllerBase
    {
        private readonly IFuncInRoleService _funcinroleService; 
        public FuncInRoleController(IFuncInRoleService funcinroleService)
        {
            _funcinroleService = funcinroleService;
        }
        //GetAllUser
        [HttpGet("GetAllFuncInRole")]
        public IEnumerable<SAM_FuncInRole> GetAllFuncInRole()
        {
            return _funcinroleService.GetAll();
        }
        //AddNewUser
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddFuncInRole(FuncInRoleRequest Fir)
        {
            try
            {
                var ad = new SAM_FuncInRole()
                {
                    RoleID = Fir.Roleid,
                    FuncID = Fir.Funcid
                };
                await _funcinroleService.Addsync(ad);
                return Ok("Add FuncInRole Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetFuncInRoleByID")]
        public async Task<IActionResult> GetFuncInRoleById([FromQuery] int id)
        {
            try
            {
                var gt = _funcinroleService.GetById(id);
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
        [HttpDelete("DeleteFuncInRole")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _funcinroleService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _funcinroleService.Remove(dlt);
                return Ok("Deleted FuncInRole Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
