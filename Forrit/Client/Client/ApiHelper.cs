using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Client
{
    public class ApiHelper
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
        public void AddKvittun(Kvittun kvittun)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(kvittun));
                client.UploadData("http://localhost:8080/api/kvittun", "POST", data);
            }
        }
    }
    public class Kvittun
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public string Vorunumer { get; set; }
        public string Strikamerki { get; set; }
        public string Byrgi { get; set; }
        public string Magn { get; set; }
        public int Verd { get; set; }
        public string Kassakerfi { get; set; }
        public override string ToString()
        {
            return Name + " " + Verd.ToString();
        }
    }    
}
