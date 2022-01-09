using Microsoft.AspNetCore.Mvc;
using AutoSzerelo_Common.Models;
using AutoSzerelo_Server.Repositories;

namespace AutoSzerelo_Server.Controllers
{
    [ApiController]
    [Route("api/repair")]
    public class CostumerController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Repair>> Get()
        {
            var repairs = RepairRepository.GetRepairs();
            return Ok(repairs);
        }

        [HttpGet("{id}")]
        public ActionResult<Repair> Get(int id)
        {

            var repair = RepairRepository.GetRepair(id);
            if (repair != null)
            {
                return Ok(repair);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Repair repair)
        {
            repair.DateOfRecording = DateTime.Now;
            repair.Status = Status.RecordedWork;
            RepairRepository.AddRepair(repair);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Repair repair, long id)
        {
            var dbRepair = RepairRepository.GetRepair(id);

            if (dbRepair != null)
            {
                RepairRepository.UpdateRepair(repair);
                return Ok();
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var repair = RepairRepository.GetRepair(id);
            if (repair != null)
            {
                RepairRepository.DeleteRepair(repair);
                return Ok();
            }

            return NotFound();
        }
    }
}
