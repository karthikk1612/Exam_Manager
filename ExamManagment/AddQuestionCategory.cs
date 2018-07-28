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

namespace ExamManagment
{
    public partial class AddQuestionCategory : Form
    {
        public AddQuestionCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString()!=null)
            {
                listBox1.Items.Add(textBox1.Text.ToString());
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                String str = "'" + textBox1.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(@"insert into login(questioncategory) values(" + str + ")", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.Text.ToString()!=null)
            {

       
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                String str = "'" + listBox1.Text.ToString() + "'";
                listBox1.Items.Remove(listBox1.SelectedItem);
                SqlCommand cmd = new SqlCommand(@"update login set questioncategory=NULL where questioncategory=" + str + ";", conn);
                cmd.ExecuteNonQuery();
                listBox1.Items.Remove(str);
                conn.Close();


            }
        }
    }
}
