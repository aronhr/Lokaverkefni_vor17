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
    }
}
