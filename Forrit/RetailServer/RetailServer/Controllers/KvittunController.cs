using RetailServer.DBConnection;
using System.Collections.Generic;
using System.Web.Http;

namespace RetailServer.Controllers
{
    public class KvittunController : ApiController
    {
        Database database = new Database();

        public void Post(Kvittun kvittun)
        {
            database.AddKvittun(kvittun.Text,kvittun.Price.ToString());
        }
    }
}
