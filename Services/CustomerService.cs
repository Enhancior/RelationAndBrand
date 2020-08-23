using ApiToExcel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToExcel.Services
{
    class CustomerService : ICustomerService
    {
        private const string subscribedUrl = "https://awesomecorp.relationbrand.com/api/GetSubscribers";
        private const string unsubscribedUrl = "https://awesomecorp.relationbrand.com/api/GetUnsubscribers";
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CustomerList> GetCustomersAsync(string endpoint)
        {
            var httpResponse = await _client.GetAsync(endpoint);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error fetching from GetCustomersAsync.");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<CustomerList>(content);

            return deserializedData; 
        }

        public IEnumerable<Customer> CompareCustomers()
        {
            var subscribedCustomers = GetCustomersAsync(subscribedUrl).Result;
            var unsubscribedCustomers = GetCustomersAsync(unsubscribedUrl).Result;


            var result = from subscribed in subscribedCustomers.list
                         where !unsubscribedCustomers.list.Any(unsubscribed => unsubscribed.Id == subscribed.Id)
                         select subscribed;

            return result;
        }
    }
}
