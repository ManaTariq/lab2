using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.user.Text) | string.IsNullOrEmpty(this.pass.Text))
            {
                MessageBox.Show("Provide User Name and Password");
            }
            string server = "localhost";
            string database = "lms";
            string uid = "root";
            string password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string UserName = user.Text;
                string Password = pass.Text;


                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE Name = '" + user.Text + "' and Password = '" + pass.Text + "'", cnn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MySqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (this.user.Text == dr["Name"].ToString() & this.pass.Text == dr["Password"].ToString())
                    {
                        MessageBox.Show("*** Login Successful ***");
                        this.Hide();
                        Form3 form = new Form3(user.Text, pass.Text); 
                        form.Show(); 
                        

                    }


                   
                    else if (this.user.Text != dr["Name"].ToString() || this.pass.Text != dr["Password"].ToString())
                    {
                        MessageBox.Show("Invalid UserName or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Access Denied!!");

                    }
                }

                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
