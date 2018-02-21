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
    public partial class Issue : Form
    {
        

        public Issue()
        {
            InitializeComponent();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string issued = Convert.ToString(listBox1.SelectedItem);
            textBox1.Text = issued;
            string server = "localhost";
            string database = "lms";
            string uid = "root";
            string password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();


                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO borrowers(artifact_name)  '" + issued + "'", conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MySqlDataReader dr1 = null;
                dr1 = cmd1.ExecuteReader();
                dr1.Close();
             

                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Added");
            }

        }

    private void Issue_Load(object sender, EventArgs e)
    {

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
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


                MySqlCommand cmd = new MySqlCommand("SELECT Name FROM books", cnn);


                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MySqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string bname = (string)dr["Name"];
                    listBox1.Items.Add(bname);
                }

                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

    }
}
