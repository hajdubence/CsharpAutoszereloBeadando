using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{   
    [ApiController]
    [Route("api/customer")]
    public class CostumerController:Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = CustomerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {

            var customer = CustomerRepository.GetCustomer(id);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Customer customer)
        {
            customer.DateOfRecording = DateTime.Now;
            customer.Status = Status.RecordedWork;
            CustomerRepository.AddCustomer(customer);
             
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Customer customer, long id)
        {
            var dbCustomer = CustomerRepository.GetCustomer(id);

            if (dbCustomer !=null)
            {
                CustomerRepository.UpdateCustomer(customer);
                return Ok();
            }

            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = CustomerRepository.GetCustomer(id);
            if (customer != null)
            { 
                CustomerRepository.DeleteCustomer(customer);
                return Ok();
            }

            return NotFound();
        }
    }
}
