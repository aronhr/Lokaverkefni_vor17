using System;

namespace ServiceDesk
{

    class Program
    {
        static void Main(string[] args)
        {
            ApiHelper api = new ApiHelper();
            Console.WriteLine("Service Desk running :)");

            // Create user
            Console.WriteLine("Enter commands.. Etc. CreateUser, CreateProduct");
            var ServerTalks = "";
            do
            {
                ServerTalks = Console.ReadLine();

                if (ServerTalks == "CreateUser")
                {
                    // Do someting
                    Console.WriteLine("Create New User!");
                    Console.Write("Kennitala: ");
                    var kennitala = Console.ReadLine();
                    Console.Write("Nafn: ");
                    var nafn = Console.ReadLine();
                    Console.Write("Kenni: ");
                    var kenni = Console.ReadLine();

                    api.AddUser(new User { Nafn = nafn, Kennitala = kennitala, Kenni = kenni });

                    ServerTalks = "";
                    Console.WriteLine("Successfully added user");

                }

                if (ServerTalks == "CreateProduct")
                {
                    // Do someting
                    Console.WriteLine("Create New broduct!");
                    Console.Write("nafn: ");
                    var nafn_vara = Console.ReadLine();
                    Console.Write("Vörunumer: ");
                    var vorunumer = Console.ReadLine();
                    Console.Write("Strikamerki: ");
                    var strikamerki = Console.ReadLine();
                    Console.Write("Byrgi: ");
                    var byrgi = Console.ReadLine();
                    Console.Write("Magn: ");
                    var magn = Console.ReadLine();
                    Console.Write("Verð: ");
                    var verd = Console.ReadLine();

                    api.AddVara(new Product { Name = nafn_vara, Vorunumer = vorunumer, Strikamerki = strikamerki, Byrgi = byrgi, Magn = magn, Verd = verd });

                    ServerTalks = "";
                    Console.WriteLine("Successfully added product");

                }
            } while (ServerTalks != "Exit" || ServerTalks != "exit");


            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();

        }
    }
}
