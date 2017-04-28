﻿using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace Client
{
    public partial class Form1 : Form
    {
        private NetworkStream output;
        private BinaryWriter writer;
        private BinaryReader reader;
        private string message = "";
        private int port = 5000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Run();
        }

        void Run()
        {
            new Thread(Connect).Start();
        }

        void Connect()
        {
            TcpClient client = null;

            try
            {

                client = new TcpClient();
                client.Connect("localhost", port);
                output = client.GetStream();
                writer = new BinaryWriter(output);
                reader = new BinaryReader(output);

                do
                {
                    try
                    {
                        message = reader.ReadString();
                        // Uncomment til að byrta message fra server
                        //MessageBox.Show(message);
                        if(message == "close")
                        {
                            Environment.Exit(Environment.ExitCode);
                        }
                    }
                    catch (Exception error)
                    {
                    }
                } while (message != "close");
            } catch (Exception ex)
            {
                Environment.Exit(Environment.ExitCode);
            }
            finally
            {
                reader.Close();
                writer.Close();
                output.Close();
                client.Close();
            }
        }
    }
}
