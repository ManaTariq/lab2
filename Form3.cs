using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Form3 : Form
    {
        string user1;
        string pass1;
        public Form3(string username,string password)
        
        {
            InitializeComponent();
            user1 = username;
            pass1 = password; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Issue I = new Issue();
            I.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fine F = new Fine(user1, pass1);
            F.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F = new Form2();
            F.Show();
        }
    }
}
