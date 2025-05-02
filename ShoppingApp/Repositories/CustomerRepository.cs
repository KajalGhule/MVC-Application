using CRMLib;
using System.Text;
using System.Text.Json;

namespace ShoppingAppMVC.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() { }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5064/api/customers/");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response into a list of Customer objects
                var customers = JsonSerializer.Deserialize<List<Customer>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return customers;
            }
            else
            {
                return new List<Customer>();
            }
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync($"http://localhost:5064/api/customers/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a list of Customer objects
                var customer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return customer;
            }
            else
            {
                return null;
            }
        }
        public Task AddCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();
            // Serialize the Customer object into JSON content
            var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("http://localhost:5064/api/customers/", jsonContent).Result;
            if (response.IsSuccessStatusCode)
            {
                // Optionally, you can handle the response if needed
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a Customer object
                var createdCustomer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new Exception("Failed to add the customer.");
            }
            return Task.CompletedTask;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer) {

            HttpClient client = new HttpClient();
            // Serialize the Customer object into JSON content
            var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:5064/api/customers/", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:5064/api/customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                //var result = response.Content.ReadAsStringAsync().Result;
                //// Deserialize the JSON response into a list of Customer objects
                //var customer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //});

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
