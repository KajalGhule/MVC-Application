using CRMLib;
using Microsoft.AspNetCore.Mvc;
using ShoppingAppMVC.Repositories;
using ShoppingAppMVC.Services;

namespace ShoppingAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Dependency Injection
            ICustomerService customerService = new CustomerService(new CustomerRepository());

            //List<Customer> customers=customerService.GetCustomers();
            List<Customer> customers = (List<Customer>)await customerService.GetAllCustomersAsync();

            return View(customers);
            //return View();
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            await customerService.AddCustomerAsync(customer);
            return RedirectToAction("Index", "Customer");
        }
        public async Task<IActionResult> Details(int id)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            Customer customer = await customerService.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                this.ViewBag.customer = customer;
            }
            //this.ViewData["customer"] = customer;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            Customer customer = await customerService.GetCustomerByIdAsync(id);

            if (customer != null)
            {
                return View(customer); // Pass customer to view
            }
            return RedirectToAction("Index", "Customer");
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            bool status = await customerService.UpdateCustomerAsync(customer);
            if (status)
            {
                return RedirectToAction("Index", "Customer");
            }
            else {
                ModelState.AddModelError("", "Failed to update customer. Please try again.");
                return View(customer);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            Customer customer = await customerService.GetCustomerByIdAsync(id);

            if (customer != null)
            {
                ViewBag.Customer = customer;
                return View(); // Pass customer to view
            }
            return RedirectToAction("Index", "Customer");
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            ICustomerService customerService = new CustomerService(new CustomerRepository());
            bool status = await customerService.DeleteCustomerAsync(id);
            if (status)
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "Failed to delete customer. Please try again.");
                return View();
            }
        }
    }
}
