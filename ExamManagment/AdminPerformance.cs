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
    public partial class AdminPerformance : Form
    {
        public AdminPerformance()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select name from login where name IS NOT NULL and name <> ''; ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow name in dt.Rows)
            {
                listBox1.Items.Add(name.Field<String>(0));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APerformance a1 = new APerformance(listBox1.Text);
            a1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }
    }
}
