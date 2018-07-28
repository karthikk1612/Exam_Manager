using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin a1 = new AdminLogin();
            a1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StaffLogin s1 = new StaffLogin();
            s1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserLogin u1 = new UserLogin();
            u1.Show();
            this.Hide();

        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
        
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
          
        }
        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
    }
}
