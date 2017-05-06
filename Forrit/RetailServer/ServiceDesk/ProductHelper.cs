using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace ServiceDesk
{
    class ProductHelper
    {
        JsonSerializer serializer = new JsonSerializer();

        private T Get<T>(string id = null)
        {
            using (WebClient client = new WebClient())
            {
                var stream = client.OpenRead("http://localhost:8080/api/product/" + (id == null ? string.Empty : id));
                using (StreamReader reader = new StreamReader(stream))
                {
                    string s = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(s);
                }
            }
        }

        public List<Product> GetProducts()
        {
            return Get<List<Product>>();
        }
        public Product GetProduct(string id)
        {
            return Get<Product>(id);
        }
        public void CreateProduct(Product product)
        {

        }

    }
}
