
using InventoryLib;
namespace InventoryRepoLib
{
    public class InvnetoryRepository
    {
        public InvnetoryRepository() { }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            //Data Access Logic Layer
            //database connection with mysql
            //using Dapper ORM
            //using ADO.NET
            //using Entity Framework Core


            return new List<Product>();

        }

    }
}
