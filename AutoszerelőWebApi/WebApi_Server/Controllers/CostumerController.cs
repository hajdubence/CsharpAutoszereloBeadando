using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;

namespace WebApi_Server.Controllers
{   
    [ApiController]
    [Route("api/customer")]
    public class CostumerController:Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(new[] {new Customer {Name = "Jhon", CarType="Audi", LicensePlate="ABC123", Problem="Nem megy",Status="Felvett", DateOfRecording = DateTime.Now } });
        }
    }
}
