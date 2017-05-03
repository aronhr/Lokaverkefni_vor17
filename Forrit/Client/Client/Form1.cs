using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    buttonEnter_Click(buttonEnter, new EventArgs());
                    break;
                case Keys.Escape:
                    clear_Click(delete, new EventArgs());
                    break;
                case Keys.Back:
                    delete_Click(delete, new EventArgs());
                    break;
                case Keys.NumPad0:
                    num_Button_Click(button0, new System.EventArgs());
                    break;
                case Keys.NumPad1:
                    num_Button_Click(button1, new System.EventArgs());
                    break;
                case Keys.NumPad2:
                    num_Button_Click(button2, new System.EventArgs());
                    break;
                case Keys.NumPad3:
                    num_Button_Click(button3, new System.EventArgs());
                    break;
                case Keys.NumPad4:
                    num_Button_Click(button4, new System.EventArgs());
                    break;
                case Keys.NumPad5:
                    num_Button_Click(button5, new System.EventArgs());
                    break;
                case Keys.NumPad6:
                    num_Button_Click(button6, new System.EventArgs());
                    break;
                case Keys.NumPad7:
                    num_Button_Click(button7, new System.EventArgs());
                    break;
                case Keys.NumPad8:
                    num_Button_Click(button8, new System.EventArgs());
                    break;
                case Keys.NumPad9:
                    num_Button_Click(button9, new System.EventArgs());
                    break;
                default:
                    break;
            }
            return true;
           // return base.ProcessCmdKey(ref msg, keyData);
        }
       
        
        private void num_Button_Click(object sender, EventArgs e)
        {
            int number;

            if(string.IsNullOrWhiteSpace(textBox.Text) || int.TryParse(textBox.Text, out number))
            {
                Button button = (Button)sender;
                textBox.Text += button.Text;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string productID = textBox.Text;
            Product product = list.FirstOrDefault(p => p.ID == productID);
            if (product == null)
            {
                textBox.Text = "VILLA ???";
                return;
            }
            textBox.Clear();
            listBox.Items.Add(product);
        }

        List<Product> list = new List<Product>()
        {
            new Product {ID ="5577" , Name = "epli", Price = 109 }
        };
        public class Product
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return Name + " " + Price;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string texti = textBox.Text;
            if (string.IsNullOrWhiteSpace(texti))
            {
                return;
            }
            int len = texti.Length;
            string nyr = texti.Substring(0, len - 1);
            textBox.Text = nyr;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }
    }
}
