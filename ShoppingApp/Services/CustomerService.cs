using CRMLib;
using ShoppingAppMVC.Repositories;

namespace ShoppingAppMVC.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) { 
            _customerRepository = customerRepository;
        }
        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return _customerRepository.GetAllCustomersAsync();
        }
        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return _customerRepository.GetCustomerByIdAsync(id);
        }
        public Task AddCustomerAsync(Customer customer)
        {
            return _customerRepository.AddCustomerAsync(customer);
        }
        public Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return _customerRepository.UpdateCustomerAsync(customer);
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            return _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
