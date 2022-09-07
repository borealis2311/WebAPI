using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Mvc;
using Services.ClassTable.User;
using Services.Model.Add;
using Services.Model.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //GetAllUser
        [HttpGet("GetAllUser")]
        public IEnumerable<SAM_UserAccount> GetAllUser()
        {
            return _userService.GetAll();
        }
        //AddNewUser
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequest user)
        {
            try
            {
                var ad = new SAM_UserAccount()
                {
                    AccountName = user.Accountname,
                    AccPwd = user.Accpwd,
                    AccountEmail = user.Accountemail,
                    RecoveryEmail = user.Recoveryemail,
                    PhoneNumber = user.Phonenumber,
                    CustomerID = user.Customerid
                };
                await _userService.Addsync(ad);
                return Ok("Add User Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetByID
        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var gt = _userService.GetById(id);
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
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] UserUpdateRequest user)
        {
            try
            {
                var ed = _userService.GetById(id);
                if (ed == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                ed.AccPwd = user.Accpwd;
                ed.AccountEmail = user.Accountemail;
                ed.RecoveryEmail = user.Recoveryemail;
                ed.PhoneNumber = user.Phonenumber;
                ed.IsBlocked = user.Isblocked;
                ed.IsActivated = !user.Isblocked;
                _userService.Update(ed);
                return Ok("Edited User Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteUser
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _userService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _userService.Remove(dlt);
                return Ok("Deleted User Successfully!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetInforofUserByID")]
        public async Task<IActionResult> GetInforById([FromQuery] int id)
        {
            return Ok(_userService.GetInforById(id));
        }
    }
}
