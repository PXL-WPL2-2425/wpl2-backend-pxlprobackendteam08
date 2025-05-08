using ClassLibrary1.Business;
using ClassLibTeam08.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;


namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet("GetInvoicesByGroup")]
        public ActionResult SelectInvoicesByGroup(int groupId)
        {
            SelectResult invoices = Invoices.GetInvoicesByGroup(groupId);
            string JSONresult = JsonConvert.SerializeObject(invoices);
            return Ok(JSONresult);
        }

        [HttpGet("GetAllInvoices")]
        public ActionResult GetAllTasks()
        {
            var invoices = Invoices.GetAllInvoices();
            return Ok(invoices);
        }
    }
}
