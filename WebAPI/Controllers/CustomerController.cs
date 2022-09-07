using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Mvc;
using Services.ClassTable.Customer;
using Services.Model.Add;
using Services.Model.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //GetAllCustomer
        [HttpGet("GetAllCustomer")]
        public async Task<IEnumerable<MD_Customer>> GetAllCustomerAsync()
        {
            return _customerService.GetAll();
        }
        //AddNewCustomer
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequest customer)
        {
            try
            {
                var mc = new MD_Customer()
                {
                    CustomerCode = customer.Customercode,
                    FullName = customer.Fullname,
                    TaxCode = customer.Taxcode,
                    Address = customer.AddRess
                };
                await _customerService.Addsync(mc);
                return Ok("Add Customer Successfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //GetCustomerByID
        [HttpGet("GetCustomerByID")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var gt = _customerService.GetById(id);
                if (gt == null)
                    return NotFound("Blank id empty or invalid id");
                return Ok(gt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //EditCustomer
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] CustomerUpdateRequest customer)
        {
            try
            {
                var ed = _customerService.GetById(id);
                if (ed == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                ed.FullName = customer.FullNameU;
                ed.TaxCode = customer.TaxCodeU;
                ed.Address = customer.AddressU;
                ed.IsBlocked = customer.Isblocked;
                _customerService.Update(ed);
                return Ok("Edited Customer Successfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DeleteCustomer
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            try
            {
                var dlt = _customerService.GetById(id);
                if (dlt == null)
                {
                    return NotFound("Blank id empty or invalid id");
                }
                _customerService.Remove(dlt);
                return Ok("Deleted Customer Successfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}




