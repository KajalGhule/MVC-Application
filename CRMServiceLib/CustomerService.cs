using System;
using CRMLib;
using CRMRepository;

namespace CRMService.Service
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomers()
        {
            return new CustomerIOManager().ReadCustomers();
        }
        public Customer GetCustomerById(int id)
        {
            List<Customer> customers = GetCustomers();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }
        public bool AddCustomer(Customer customer)
        {
            try
            {
                List<Customer> customers = GetCustomers();
                customers.Add(customer);
                new CustomerIOManager().WriteCustomers(customers);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteCustomer(int id)
        {
            List<Customer> customers = GetCustomers();
            Customer c = customers.FirstOrDefault(customer => customer.Id == id);
            customers.Remove(c);
            new CustomerIOManager().WriteCustomers(customers);
        }

        public void UpdateCustomer(Customer customer)
        {
            List<Customer> customers = GetCustomers();
            Customer cust = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (cust != null) { 
                cust.Name = customer.Name;
                cust.Email = customer.Email;
                cust.ContactNumber = customer.ContactNumber;
                cust.Age = customer.Age;
                cust.Location = customer.Location;
                new CustomerIOManager().WriteCustomers(customers);
            }
        }
    }
}
