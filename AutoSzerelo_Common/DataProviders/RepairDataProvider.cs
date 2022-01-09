using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoSzerelo_Common.Models;

namespace AutoSzerelo_Common.DataProviders
{
    public class RepairDataProvider
    {
        private const string _url = "http://localhost:5000/api/repair";

        public static IEnumerable<Repair> GetRepairs()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var repairs = JsonConvert.DeserializeObject<IEnumerable<Repair>>(rawData);
                    return repairs;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }
        public static Repair GetRepair(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var repair = JsonConvert.DeserializeObject<Repair>(rawData);
                    return repair;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void AddRepair(Repair repair)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(repair);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync($"{_url}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateRepair(Repair repair, long id)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(repair);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{_url}/{id}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteRepair(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
