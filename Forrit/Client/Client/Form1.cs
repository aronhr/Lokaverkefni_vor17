using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private ProductHelper api = new ProductHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //Run();
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
        }

        private void num_Button_Click(object sender, EventArgs e)
        {
            int number;

            if (string.IsNullOrWhiteSpace(textBox.Text) || int.TryParse(textBox.Text, out number))
            {
                Button button = (Button)sender;
                textBox.Text += button.Text;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string productID = textBox.Text;
            Product product = api.GetProduct(productID);
            if (product == null)
            {
                textBox.Text = "VILLA ???";
                return;
            }
            textBox.Clear();
            listBox.Items.Add(product);
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
