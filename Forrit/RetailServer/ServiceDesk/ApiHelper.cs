using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
namespace ServiceDesk
{
    public class ApiHelper
    {

        JsonSerializer serializer = new JsonSerializer();
        public void Post<T>(T obj, string controller)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                client.UploadData("http://localhost:8080/api/"+ controller, "POST", data);
            }
        }

        public void AddVara(Product product)
        {
            Post<Product>(product, "product");
        }
        public void AddUser(User user)
        {
            Post<User>(user, "user");
        }
    }
    public class User
    {
        public string Kennitala { get; set; }
        public string Nafn { get; set; }
        public string Kenni { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public string Vorunumer { get; set; }
        public string Strikamerki { get; set; }
        public string Byrgi { get; set; }
        public string Magn { get; set; }
        public string Verd { get; set; }
        public string Kassakerfi { get; set; }
        public string Staff { get; set; }
    }
}
