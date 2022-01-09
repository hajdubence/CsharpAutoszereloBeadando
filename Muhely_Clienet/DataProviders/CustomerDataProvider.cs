using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace AutoSzerelo_Client.DataProviders
{
    class CustomerDataProvider
    {
        private const string _url = "http://localhost:5000/api/customer";

        public static IEnumerable<Repair> GetCustomers()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var customers = JsonConvert.DeserializeObject<IEnumerable<Repair>>(rawData);
                    return customers;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void UpdateCustomer(Repair customer, long id)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(customer);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{_url}/{id}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
