using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int attempt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                MessageBox.Show("Successfully Logged In!!!");

                this.Hide();

                new Form2().ShowDialog();

                this.Show();
            }
            else
            {
                if (attempt == 2)
                {
                    MessageBox.Show("You have used all attempts!");
                    this.Close();
                }
                else
                {
                    attempt++;
                    MessageBox.Show($"Wrong username or password! ({3 - attempt} attempts left)");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
