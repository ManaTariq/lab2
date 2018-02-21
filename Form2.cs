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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //button to open database
        private void Button1_Click(object sender, EventArgs e)
        {
            ListBox listBox1 = new ListBox();
            
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM books", cnn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MySqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Database.Items.Add(dr.GetString(0));
                    Database.Items.Add(dr.GetString(1));
                    Database.Items.Add(dr.GetString(2));
                    Database.Items.Add(dr.GetString(3));
                    Database.Items.Add(dr.GetString(4));
                    Database.Items.Add(dr.GetString(5));


                }

                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }




        // //string server = "localhost";
        //// string database = "lab2sc";
        // //string uid = "root";
        //// string password = "bitch135";
        // string connectionString;
        // connectionString = "server=localhost;port=3306;username=root;password=bitch135;database=lab2sc;";
        // MySqlConnection cnn = new MySqlConnection(connectionString);
        // try
        // {
        //     cnn.Open();



        //     MySqlCommand cmd = new MySqlCommand("SELECT * FROM books ", cnn);

        //     MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //     MySqlCommand cmdd = new MySqlCommand("SELECT * FROM dvd ", cnn);

        //     MySqlDataAdapter daa = new MySqlDataAdapter(cmdd);
        //     MySqlCommand cmddd = new MySqlCommand("SELECT * FROM journals ", cnn);

        //     MySqlDataAdapter daaa = new MySqlDataAdapter(cmddd);
        //     DataTable dt = new DataTable();
        //     DataTable dtt = new DataTable();
        //     DataTable dttt = new DataTable();
        //     da.Fill(dt);
        //     daa.Fill(dtt);
        //     daaa.Fill(dttt);

        //     MySqlDataReader dr = null;
        //     dr = cmd.ExecuteReader();
        //     MySqlDataReader drr = null;
        //     drr = cmdd.ExecuteReader();
        //     MySqlDataReader drrr = null;
        //     drrr = cmddd.ExecuteReader();
        //     if (dr.HasRows)
        //     {

        //         while (dr.Read())
        //         {
        //             string[] row = { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3),
        //                              dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetString(8), dr.GetString(9), dr.GetString(10), };
        //             listBox1.Items.Add(row[1] + "            " + row[5] + "       " + row[2] + " by " + row[3] + " is " + row[10]);


        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No rows found.");
        //     }
        //     if (drr.HasRows)
        //     {

        //         while (drr.Read())
        //         {
        //             string[] row = { drr.GetString(0), drr.GetString(1), drr.GetString(2), drr.GetString(3),
        //                              drr.GetString(4), drr.GetString(5), drr.GetString(6), drr.GetString(7), drr.GetString(8), drr.GetString(9), drr.GetString(10), };
        //             listBox1.Items.Add(row[1] + "            " + row[5] + "       " + row[2] + " by " + row[3] + " is " + row[10]);


        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No rows found.");
        //     }
        //     if (drrr.HasRows)
        //     {

        //         while (drrr.Read())
        //         {
        //             string[] row = { drrr.GetString(0), drrr.GetString(1), drrr.GetString(2), drrr.GetString(3),
        //                              drrr.GetString(4), drrr.GetString(5), drrr.GetString(6), drrr.GetString(7), drrr.GetString(8), drrr.GetString(9), drrr.GetString(10), };
        //             listBox1.Items.Add(row[1] + "            " + row[5] + "       " + row[2] + " by " + row[3] + " is " + row[10]);
        //             // allRecordsListBox.Items.Add(row[2]);

        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No rows found.");
        //     }

        //     cnn.Close();
        // }
        // catch (Exception)
        // {
        //     MessageBox.Show("Can not opegfhffn Database ! ");
       // }

   // }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
           
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Database_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //button to search by TITLE
        private void button2_Click(object sender, EventArgs e)
        {
            ListBox listBox1 = new ListBox();
            string Title = textBox1.Text;
            string Author = textBox2.Text;
            string Genre = textBox3.Text;
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM books WHERE Name = '" + Title + "'", cnn);

                MySqlDataReader dr = null;
                dr = cmd.ExecuteReader();


                // If there are available rows
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Database.Items.Add(dr.GetString(0));
                        Database.Items.Add(dr.GetString(1));
                        Database.Items.Add(dr.GetString(2));
                        Database.Items.Add(dr.GetString(3));
                        Database.Items.Add(dr.GetString(4));
                        Database.Items.Add(dr.GetString(5));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
             
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Cant open database!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //button to search by AUTHOR
        private void button3_Click(object sender, EventArgs e)
        {
            ListBox listBox1 = new ListBox();
            string Title = textBox1.Text;
            string Author = textBox2.Text;
            string Genre = textBox3.Text;
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

                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommand cmdd = new MySqlCommand("SELECT * FROM books WHERE Author = '" + Author + "'", cnn);

                MySqlDataReader drr = null;
                drr = cmdd.ExecuteReader();
                

                // If there are available rows
               
                if (drr.HasRows)
                {
                    while (drr.Read())
                    {
                        Database.Items.Add(drr.GetString(0));
                        Database.Items.Add(drr.GetString(1));
                        Database.Items.Add(drr.GetString(2));
                        Database.Items.Add(drr.GetString(3));
                        Database.Items.Add(drr.GetString(4));
                        Database.Items.Add(drr.GetString(5));

                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Cant open database!!");
            }
        }
        //button to search by GENRE of book
        private void button4_Click(object sender, EventArgs e)
        {
            ListBox listBox1 = new ListBox();
           
            string Genre = textBox3.Text;
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


                //MySqlDataAdapter daa = new MySqlDataAdapter(cmdd);
                MySqlCommand cmddd = new MySqlCommand("SELECT * FROM books WHERE Genre  = '" + Genre + "'", cnn);


               
                MySqlDataReader drrr = null;
                drrr = cmddd.ExecuteReader();

                // If there are available rows
                if (drrr.HasRows)
                {
                    while (drrr.Read())
                    {
                        Database.Items.Add(drrr.GetString(0));
                        Database.Items.Add(drrr.GetString(1));
                        Database.Items.Add(drrr.GetString(2));
                        Database.Items.Add(drrr.GetString(3));
                        Database.Items.Add(drrr.GetString(4));
                        Database.Items.Add(drrr.GetString(5));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Cant open database!!");
            }

        }
    }
}
