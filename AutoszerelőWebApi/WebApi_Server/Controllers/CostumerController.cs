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
            var customers = CustomerRepository.GetCustomers();

            var customer = customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Customer customer)
        {
            var customers = CustomerRepository.GetCustomers().ToList();
            customer.Id = GetNewId(customers);
            customers.Add(customer);

            CustomerRepository.StoreCustomers(customers);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Customer customer)
        {
            var customers = CustomerRepository.GetCustomers().ToList();

            var customerToUpdate = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = customer.Name;
                customerToUpdate.CarType = customer.CarType;
                customerToUpdate.LicensePlate = customer.LicensePlate;
                customerToUpdate.Problem = customer.Problem;
                customerToUpdate.Status = customer.Status;

                CustomerRepository.StoreCustomers(customers);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customers = CustomerRepository.GetCustomers().ToList();
            var customerToDelete = customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {
                customers.Remove(customerToDelete);

                CustomerRepository.StoreCustomers(customers);
                return Ok();
            }

            return NotFound();
        }

        private long GetNewId(IEnumerable<Customer> customers)
        {
            long newId = 0;
            foreach (var customer in customers)
            {
                if (customer.Id > newId)
                {
                    newId = customer.Id;
                }
            }
            return newId + 1;
        }
    }
}
