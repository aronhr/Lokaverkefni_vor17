using RetailServer.DBConnection;
using System.Collections.Generic;
using System.Web.Http;

namespace RetailServer.Controllers
{
    public class ProductController:ApiController
    {
        Database database = new Database();

        // GET api/product
        public IEnumerable<Product> Get()
        {
            return database.GetAllarVorur();
        }

        // GET api/product/5501
        public Product Get(string id)
        {
            return database.GetEinaVoru(id);
        }

        public void Post(Product product)
        {
            database.AddProduct(product.Name, product.Vorunumer, product.Strikamerki, product.Byrgi, product.Magn, product.Verd);
        }

        public IEnumerable<Product> GetVorurFyrirKassa()
        {
            return database.GetVorurOnDeck();
        }
    }       
}
