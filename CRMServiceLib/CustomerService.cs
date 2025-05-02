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

        public bool DeleteCustomer(int id)
        {
            List<Customer> customers = GetCustomers();
            Customer c = customers.FirstOrDefault(customer => customer.Id == id);
            if (c != null)
            {
                customers.Remove(c);
                new CustomerIOManager().WriteCustomers(customers);
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            List<Customer> customers = GetCustomers();
            Customer cust = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (cust != null) { 
                cust.Id = customer.Id;         
                cust.Name = customer.Name;
                cust.Email = customer.Email;
                cust.ContactNumber = customer.ContactNumber;
                cust.Age = customer.Age;
                cust.Location = customer.Location;
                new CustomerIOManager().WriteCustomers(customers);
                return true;
            }
            return false;
        }
    }
}
