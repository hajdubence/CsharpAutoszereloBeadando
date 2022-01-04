using System.Text.Json;
using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public static class CustomerRepository
    {
        private const string filename = "Customer.json";

        public static IEnumerable<Customer> GetCustomers()
        {
            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var customers = JsonSerializer.Deserialize<IEnumerable<Customer>>(rawData);
                return customers;
            }

            return new List<Customer>();
        }

        public static void StoreCustomers(IEnumerable<Customer> customers)
        {
            var rawData = JsonSerializer.Serialize(customers);
            File.WriteAllText(filename, rawData);
        }
    }
}
