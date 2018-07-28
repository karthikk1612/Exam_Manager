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
    public partial class StaffPage : Form
    {
       public String s1;
        public StaffPage(String str)
        {
            InitializeComponent();
            s1 = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAddQuestions a1 = new SAddQuestions(s1);
            a1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Approve a1 = new Approve(s1);
            a1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserDetails u1 = new UserDetails(s1,"");
            u1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Performance p1 = new Performance(s1);
            p1.Show();
            this.Hide();
        }
    }
}
