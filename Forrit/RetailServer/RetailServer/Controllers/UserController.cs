using RetailServer.DBConnection;
using System.Collections.Generic;
using System.Web.Http;


namespace RetailServer.Controllers
{
    public class UserController:ApiController
    {
        Database database = new Database();

        public bool CreateUser(string kennitala, string nafn, string kenni)
        {
            return database.CreateUser(kennitala, nafn, kenni);
        }

        public bool AddProduct(string nafn, string vorunumer, string strikamerki, string byrgi, string magn, string verd)
        {
            return database.AddProduct(nafn, vorunumer, strikamerki, byrgi, magn, verd);
        }
    }
}
