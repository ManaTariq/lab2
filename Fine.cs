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
    public partial class Fine : Form
    {

        string user, pass;

        public Fine(string username, string password)
        {
            InitializeComponent();
            user = username;
            pass = password;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            }

        private void button1_Click(object sender, EventArgs e)
        {
            int fine = 0;
            string server = "localhost";
            string database = "lms";
            string uid = "root";
            string password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cnn = new MySqlConnection(connectionString);
            cnn.Open();

            MySqlCommand cmd1 = new MySqlCommand("SELECT user_id FROM users WHERE Name = '" + user + "' and Password = '" + pass + "'", cnn);
            MySqlDataAdapter userid = new MySqlDataAdapter(cmd1);
            DataTable user_id = new DataTable();
            userid.Fill(user_id);
            int id = 0;
            foreach (DataRow dr in user_id.Rows)
            {
                id = (int)dr["user_id"];
            }


            MySqlCommand cmd2 = new MySqlCommand("SELECT artifact_type,Du_date FROM borrowers WHERE User_id = '" + id + "'", cnn);
            MySqlDataAdapter d1 = new MySqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            d1.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                DateTime now = DateTime.Now;
                DateTime tr = (DateTime)dr["Du_date"];
                TimeSpan t = tr - now;
                double days = t.TotalDays;
                int remain = (int)days;
                if (remain <= 0)
                {
                    int count = remain * -1;

                    if (dr["artifact_type"].ToString() == "book")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            fine += 50;
                        }
                    }
                    else if (dr["artifact_type"].ToString() == "journal")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            fine += 100;
                        }
                    }
                }
            }
            textBox1.Text = fine.ToString();
        }
        }
    }

