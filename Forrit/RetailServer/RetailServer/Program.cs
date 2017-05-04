﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using RetailServer.Controllers;

namespace RetailServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UserController user = new UserController();
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Web Server is running.");

                // Create user
                Console.WriteLine("Enter commands.. Etc. CreateUser, CreateProduct");
                var ServerTalks = "";
                do
                {
                    ServerTalks = Console.ReadLine();

                    if (ServerTalks == "CreateUser")
                    {
                        // Do someting
                        Console.Write("Kennitala: ");
                        var kennitala = Console.ReadLine();
                        Console.Write("Nafn: ");
                        var nafn = Console.ReadLine();
                        Console.Write("Kenni: ");
                        var kenni = Console.ReadLine();

                        user.CreateUser(kennitala, nafn, kenni);

                        ServerTalks = "";

                    }

                    if (ServerTalks == "CreateProduct")
                    {
                        // Do someting

                    }
                } while (ServerTalks != "Exit" || ServerTalks != "exit");
                

                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            SupportJson(config);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }

        private void SupportJson(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            // support enum as well
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
        }
    }
}
