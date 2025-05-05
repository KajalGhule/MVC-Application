using Microsoft.AspNetCore.Mvc;
 
using ShipmentLib;

namespace ShipmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        // GET: api/<ShipmentController>
        [HttpGet]
        public IEnumerable<Shipment> Get()
        {
            List<Shipment> shipments = new List<Shipment>();
            // Sample data
            // In a real application, this data would come from a database or other data source
            shipments.Add(new Shipment { Id = 1, ShipmentNumber = "S123", Origin = "New York", Destination = "Los Angeles", ShipmentDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(5), Status = "In Transit", Carrier = "FedEx", TrackingNumber = "F123456789" });
            shipments.Add(new Shipment { Id = 2, ShipmentNumber = "S124", Origin = "Chicago", Destination = "Miami", ShipmentDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(3), Status = "Delivered", Carrier = "UPS", TrackingNumber = "U987654321" });
            

            return shipments;

        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public Shipment Get(int id)
        {
            return  new Shipment { Id = 1, ShipmentNumber = "S123", Origin = "New York", Destination = "Los Angeles", ShipmentDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(5), Status = "In Transit", Carrier = "FedEx", TrackingNumber = "F123456789" };
        }

        // POST api/<ShipmentController>
        [HttpPost]
        public void Post([FromBody] Shipment value)
        {
            // Add shipment to the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
            // using ADO.NET
            // using Entity Framework Core
        }

        // PUT api/<ShipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shipment value)
        {
            // Update shipment in the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Delete shipment from the database
            // Data Access Logic Layer
            // database connection with mysql
            // using Dapper ORM
            // using ADO.NET
            // using Entity Framework Core
        }
    }
}
