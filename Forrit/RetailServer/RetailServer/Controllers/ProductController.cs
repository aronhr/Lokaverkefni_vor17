using RetailServer.DBConnection;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RetailServer.Controllers
{
    public class ProductController:ApiController
    {
        Database database = new Database();
        // dummy database
        IEnumerable<Product> list = new List<Product>()
        {
            new Product {ID ="5577" , Name = "epli", Price = 109 }
        };

        // GET api/product
        public IEnumerable<Product> Get()
        {
            return database.GetAllarVorur();
        }

        // GET api/product/5
        public Product Get(string id)
        {
            return database.GetEinaVoru(id);
        }
    }
    
   
}
