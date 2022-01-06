using System.Text.Json;
using WebApi_Common.Models;
using WebApi_Server.Properties;

namespace WebApi_Server.Repositories
{
    public static class CustomerRepository
    {

        public static IEnumerable<Customer> GetCustomers()
        {
            using(var database = new CustomerContext())
            {
                var customers = database.Customers.OrderBy(c => c.DateOfRecording).ToList();

                return customers;
            }
        }

        public static Customer GetCustomer(long id)
        {
            using (var database = new CustomerContext())
            {
                var customer = database.Customers.Where(c => c.Id == id).FirstOrDefault();

                return customer;
            }
        }

        public static void AddCustomer(Customer customer)
        {
            using (var database = new CustomerContext())
            {
                database.Customers.Add(customer);

                database.SaveChanges();
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            using (var database = new CustomerContext())
            {
                database.Customers.Update(customer);

                database.SaveChanges();


            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            using (var database = new CustomerContext())
            {
                database.Customers.Remove(customer);

                database.SaveChanges();
            }
        }
    }
}
