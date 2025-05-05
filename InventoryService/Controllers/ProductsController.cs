using Microsoft.AspNetCore.Mvc;

using InventoryLib;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Rose", Description = "Wedding flower" });
            products.Add(new Product { Id = 2, Name = "Lilly", Description = "Wedding flower" });
            products.Add(new Product { Id = 3, Name = "Tulip", Description = "Wedding flower" });
            products.Add(new Product { Id = 4, Name = "Daisy", Description = "Wedding flower" });

            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = new Product { Id = 1, Name = "Rose", Description = "Wedding flower" };
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            // Add product to the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
            // using ADO.NET
            // using Entity Framework Core
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Update product in the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
            // using ADO.NET
            // using Entity Framework Core
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Delete product from the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
            // using ADO.NET
            // using Entity Framework Core

        }
    }
}
