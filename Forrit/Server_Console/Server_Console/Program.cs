using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Server_Console
{
    class Program
    {
        private Socket connection;
        private int counter = 0;
        private int port = 5000;
        db_connect conn = new db_connect();
        static void Main(string[] args)
        {
            new Program().Run();
        }

        void Run()
        {
            new Thread(RunServer).Start();
        }

        public void RunServer()
        {
            Thread readThread;
            bool done = false;

            TcpListener listener;

            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Ready for connection..");
                while (!done)
                {
                    connection = listener.AcceptSocket();
                    counter++;
                    Console.WriteLine("Connected!");
                    readThread = new Thread(GetMessages);
                    readThread.Start();

                    // Commands
                    string serverTalks = Console.ReadLine();

                    if(serverTalks == "CreateUser")
                    {
                        // Create new user with db_connect.CreateUser();
                        Console.WriteLine("Kennitala: ");
                        string kennitala = Console.ReadLine();
                        Console.WriteLine("Nafn: ");
                        string nafn = Console.ReadLine();
                        Console.WriteLine("Kenni: ");
                        string kenni = Console.ReadLine();
                        Console.WriteLine(kennitala + nafn + kenni);
                        Console.ReadKey();
                        conn.CreateUser(kennitala,nafn,kenni);
                        Console.WriteLine("User created");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        } // RunServer END

        public void GetMessages()
        {
            Socket socket = connection;
            int count = counter;
            NetworkStream socketStrem = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;

            try
            {
                socketStrem = new NetworkStream(socket);
                reader = new BinaryReader(socketStrem);
                writer = new BinaryWriter(socketStrem);
                writer.Write("Connecteddddddd!");
                do
                {
                    string message = null;
                    message = Console.ReadLine();
                    writer.Write(message);
                } while (true);
                
                // do something with messages
                // Input frá Client koma herna!

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                reader.Close();
                writer.Close();
                socketStrem.Close();
                socket.Close();
            }
        }
    }
}

