using System;
using CRMLib;

namespace CRMService.Service
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        bool AddCustomer(Customer customer);

        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
