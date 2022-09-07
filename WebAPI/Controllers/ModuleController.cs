using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Mvc;
using Services.ClassTable.Module;
using Services.Model.Add;
using Services.Model.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }
        //GetAllModule
        [HttpGet("GetAllModule")]
        public IEnumerable<SAM_Module> GetAllModule()
        {
            return _moduleService.GetAll();
        }
        //AddNewModule
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleRequest module)
        {
            try
            {
                var ad = new SAM_Module()
                {
                    ModuleCode = module.Modulecode,
                    ModuleDesc = module.Moduledesc,
                    Icon = module.Icon,
                    OrderNo = module.Orderno
                };
                await _moduleService.Addsync(ad);
                return Ok("Add Module Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetModuleByID")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var gt = _moduleService.GetById(id);
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
        [HttpPut("UpdateModule")]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] ModuleUpdateRequest module)
        {
            try
            {
                var ed = _moduleService.GetById(id);
                if (ed == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                ed.ModuleDesc = module.ModuledescU;
                ed.Icon = module.IconU;
                ed.OrderNo = module.OrdernoU;
                ed.IsBlocked = module.Isblocked;
                _moduleService.Update(ed);
                return Ok("Edited Module Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteUser
        [HttpDelete("DeleteModule")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _moduleService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _moduleService.Remove(dlt);
                return Ok("Deleted Module Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
