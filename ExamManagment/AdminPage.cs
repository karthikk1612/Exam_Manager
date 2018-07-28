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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StaffDetails s1 = new StaffDetails();
            s1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStaff a1 = new AddStaff();
            a1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddQuestionCategory a1 = new AddQuestionCategory();
            a1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddQuestions a1 = new AddQuestions();
            a1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserADetails u1 = new UserADetails();
            u1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPerformance a1 = new AdminPerformance();
            a1.Show();
            this.Hide();
        }
    }
}
