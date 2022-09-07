using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Mvc;
using Services.ClassTable.Function;
using Services.Model.Add;
using Services.Model.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }
        //GetAllFunction
        [HttpGet("GetAllFunction")]
        public IEnumerable<SAM_Function> GetAllFunction()
        {
            return _functionService.GetAll();
        }
        //AddNewFunction
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddFunction(FunctionRequest func)
        {
            try
            {
                var ad = new SAM_Function()
                {
                    FuncCode = func.Funccode,
                    FuncDesc = func.Funcdesc,
                    URL = func.UrL,
                    OrderNo = func.Orderno,
                    ModuleID = func.Moduleid
                };
                await _functionService.Addsync(ad);
                return Ok("Add Function Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetFunctionByID")]
        public async Task<IActionResult> GetFunctionById([FromQuery] int id)
        {
            try
            {
                var gt = _functionService.GetById(id);
                if (gt == null)
                    return NotFound("Blank id empty or invalid id");
                return Ok(gt);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //EditFunction
        [HttpPut("UpdateFunction")]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] FunctionUpdateRequest func)
        {
            try
            {
                var ed = _functionService.GetById(id);
                if (ed == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }

                ed.FuncDesc = func.Funcdesc;
                ed.URL = func.UrL;
                ed.OrderNo = func.Orderno;
                ed.IsBlocked = func.Isblocked;
                _functionService.Update(ed);
                return Ok("Edited Function Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteFunction
        [HttpDelete("DeleteFunction")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _functionService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _functionService.Remove(dlt);
                return Ok("Deleted Function Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
