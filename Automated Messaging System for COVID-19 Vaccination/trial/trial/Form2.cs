using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace trial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            display_data();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\YaNawMe\Documents\trial.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                textBox7.Text == "" ||
                textBox8.Text == "" ||
                textBox9.Text == "")
            {
                MessageBox.Show("Missing Fields");
            }

            else
            {
                SqlDataAdapter dconn = new SqlDataAdapter("Select ID From resident where ID ='" + textBox1.Text + "'", conn);
                DataTable dtable = new DataTable();

                dconn.Fill(dtable);

                if (dtable.Rows.Count >= 1)
                {
                    MessageBox.Show("ID Number is Existing");
                }

                else
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into resident values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";

                    display_data();

                    MessageBox.Show("Personal Details Recorded Sucessfully");
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
        }

        public void display_data()
        {
            conn.Open();


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from resident";
            cmd.ExecuteNonQuery();

            DataTable dtable = new DataTable();
            SqlDataAdapter dconn = new SqlDataAdapter(cmd);
            dconn.Fill(dtable);

            dataGridView1.DataSource = dtable;

            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dconn = new SqlDataAdapter("Select ID From resident where ID ='" + textBox1.Text + "'", conn);
            DataTable dtable = new DataTable();

            dconn.Fill(dtable);

            if (dtable.Rows.Count < 1)
            {
                MessageBox.Show("ID Number doesn't exist!");
            }

            else
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE resident SET Lname = '" + textBox2.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Mname = '" + textBox3.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Fname = '" + textBox4.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Age = '" + textBox5.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Gender = '" + textBox6.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Address = '" + textBox7.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Cnumber= '" + textBox8.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE resident SET Vaccine = '" + textBox9.Text + "' WHERE ID = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();

                conn.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                display_data();

                MessageBox.Show("Personal Details Recorded Sucessfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ID"].Value);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Please select a proper ID inside the table.");
            }

            else
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from resident where ID = '" + dataGridView1.CurrentCell.Value + "'";
                cmd.ExecuteNonQuery();

                conn.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                display_data();

                MessageBox.Show("Personal Details Deleted Sucessfully");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter an ID Number!");
            }

            else
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from resident where ID='" + textBox1.Text + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    textBox2.Text = sdr[1].ToString();
                    textBox3.Text = sdr[2].ToString();
                    textBox4.Text = sdr[3].ToString();
                    textBox5.Text = sdr[4].ToString();
                    textBox6.Text = sdr[5].ToString();
                    textBox7.Text = sdr[6].ToString();
                    textBox8.Text = sdr[7].ToString();
                    textBox9.Text = sdr[8].ToString();

                    sdr.Close();
                }

                cmd.Dispose();

                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            MessageBox.Show("All Fields Are Removed!");
        }

        public object itexmo(string Number, string Message, string ApiCode, string ApiPassword)
        {
            object functionReturnValue = null;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();

                string url = "https://www.itexmo.com/php_api/api.php";

                parameter.Add("1", Number);
                parameter.Add("2", Message);
                parameter.Add("3", ApiCode);
                parameter.Add("passwd", ApiPassword);

                dynamic rpb = client.UploadValues(url, "POST", parameter);

                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }

            return functionReturnValue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string api = "TR-EPHRA329001_HZXWW";
            string api_password = "diy3c4hm5n";
            string message = textBox10.Text;
            string number = textBox8.Text;

            dynamic result = itexmo(number, message, api, api_password);

            if (result == "0")
            {
                MessageBox.Show("Message Sent");
            }

            else
            {
                MessageBox.Show("Error num " + result + " was encountered");
            }
        }
    }
}
