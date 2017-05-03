using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Client
{
    public class ProductHelper
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
    }

    public class Product
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return Name + " " + Price;
        }
    }
}
