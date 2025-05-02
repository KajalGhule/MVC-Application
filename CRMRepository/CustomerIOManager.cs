using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CRMLib;

namespace CRMRepository
{
    public class CustomerIOManager
    {
        public CustomerIOManager() { }

        public List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string filePath = @"D:/TAP/WeekEndBatchProject/MVC-Application/ShoppingApp/MVC-Application/customers.json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
            }
            return customers;
        }

        public void WriteCustomers(List<Customer> customers)
        {
            //Serialize customers
            //write customers to file
            string jsonString = JsonSerializer.Serialize(customers);
            string filePath = @"D:/TAP/WeekEndBatchProject/MVC-Application/ShoppingApp/MVC-Application/customers.json";
            File.WriteAllText(filePath, jsonString);
        }
    }
}
