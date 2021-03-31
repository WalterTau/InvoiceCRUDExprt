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
    public class InvoiceController : Controller
    {
        private IInvoiceService _invoice;
        public InvoiceController(IInvoiceService invoice)
        {
            this._invoice = invoice;
        }

        [HttpPost]
        public ActionResult Post(Invoice model)
        {
            return Ok(_invoice.Add(model));

        }

        [HttpGet]

        public async Task<ActionResult<List<Invoice>>> Get()
        {

            return Ok(await _invoice.GetInvoices());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Invoice>), 200)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _invoice.Get(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Invoice>), 200)]
        public async Task<IActionResult> Update(int id, Invoice model)
        {
            return Ok(await _invoice.Update(id, model));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Invoice>), 200)]
        public  ActionResult Delete(int id)
        {
            return Ok(_invoice.Delete(id));
        }
    }
}
