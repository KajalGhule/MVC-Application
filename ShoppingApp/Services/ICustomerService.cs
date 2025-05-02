using CRMLib;

namespace ShoppingAppMVC.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);

        Task<bool> DeleteCustomerAsync(int id);
    }
}
