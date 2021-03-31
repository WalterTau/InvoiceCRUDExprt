using InvoiceManagementApp.Api.Data;
using InvoiceManagementApp.Api.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
            this._customer = customer;
        }

        [HttpPost]
        public ActionResult Post(Customer model)
        {
            return Ok(_customer.Add(model));

        }
      
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {

            return Ok(await _customer.GetCustomers());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Customer>), 200)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _customer.Get(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Customer>), 200)]
        public async Task<IActionResult> Update(int Id, Customer model)
        {
            return Ok(await _customer.Update(Id, model));
        }
    }
}
