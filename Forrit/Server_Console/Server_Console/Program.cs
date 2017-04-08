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

                while (!done)
                {
                    connection = listener.AcceptSocket();
                    counter++;
                    readThread = new Thread(GetMessages);
                    readThread.Start();
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
                writer.Write("Connected!");
                string message = null;

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

