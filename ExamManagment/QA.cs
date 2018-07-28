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
    public partial class QA : Form
    {
        public String s1,s2,z1;
        public int i = 1, count = 0,total,first=0;
        public QA(String str,String snr)
        {
            InitializeComponent();
            s1="'"+str+"'";
            s2 = "'" + snr + "'";
            listBox1.Hide();
            label3.Hide();
            total = counts();
            if (i == total)
            {
                MessageBox.Show("No Questions in this category. please select another!");
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
               SqlCommand cmd = new SqlCommand(@"select username from login where name=" +s2+ "", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    z1 = dr.GetString(0).ToString();
                }
                Userpage u1 = new Userpage(z1);
                u1.Show();
                this.Hide();
            }
            else
            {
                label3.Text = "Score =" + count + "";
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"select Qno,question,option1,option2,option3,option4,answer from login where Qno=" + i + "and category=" + s1 + "", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label1.Text = dr.GetInt32(0).ToString();
                    label2.Text = dr.GetString(1).ToString();
                    radioButton1.Text = dr.GetString(2).ToString();
                    radioButton2.Text = dr.GetString(3).ToString();
                    radioButton3.Text = dr.GetString(4).ToString();
                    radioButton4.Text = dr.GetString(5).ToString();

                }
                conn.Close();
            }
        }

        private void QA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (first == 0)
            {
                SqlConnection connn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                connn.Open();
                SqlCommand cmdn = new SqlCommand("select Qno,question,option1,option2,option3,option4,answer from login where Qno=" + i + "and category=" + s1 + "", connn);
                SqlDataReader drr = cmdn.ExecuteReader();
                if (drr.Read())
                {
                    label1.Text = drr.GetInt32(0).ToString();
                    label2.Text = drr.GetString(1).ToString();
                    radioButton1.Text = drr.GetString(2).ToString();
                    radioButton2.Text = drr.GetString(3).ToString();
                    radioButton3.Text = drr.GetString(4).ToString();
                    radioButton4.Text = drr.GetString(5).ToString();
                    {
                        if (radioButton1.Checked == true)
                        {
                            if (radioButton1.Text.ToString() == drr.GetString(6).ToString())
                            {
                                count++;
                                label3.Text = "Score =" + count + "";
                            }
                        }
                        if (radioButton2.Checked == true)
                        {
                            if (radioButton2.Text.ToString() == drr.GetString(6).ToString())
                            {
                                count++;
                                label3.Text = "Score =" + count + "";
                            }
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (radioButton3.Text.ToString() == drr.GetString(6).ToString())
                            {
                                count++;
                                label3.Text = "Score =" + count + "";
                            }
                        }
                        if (radioButton4.Checked == true)
                        {
                            if (radioButton4.Text.ToString() == drr.GetString(6).ToString())
                            {
                                count++;
                                label3.Text = "Score =" + count + "";
                            }
                        }
                    }
                    first++;
                    i++;
                }
            }
        
            if (i == total)
            {
                label3.Show();
                MessageBox.Show("Test Completed Successfully!");
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select ctgr,uname from login where uname=" + s2 + "and ctgr=" + s1 + "", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    cmd.CommandText = "update login set score=" + count + "where uname=" + s2 + "and ctgr=" + s1 + "";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    String f1 = "" + count + "," + s1 + "," + s2 + "";
                    cmd.CommandText = @"insert into login(score,ctgr,uname) values("+f1+")";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "select username from login where name=" + s2 + "";
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    z1 = dr.GetString(0).ToString();
                }
                Userpage u1 = new Userpage(z1);
                u1.Show();
                this.Hide();
            }
            else
            {
                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Qno,question,option1,option2,option3,option4,answer from login where Qno=" + i + "and category=" + s1 + "", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label1.Text = dr.GetInt32(0).ToString();
                    label2.Text = dr.GetString(1).ToString();
                    radioButton1.Text = dr.GetString(2).ToString();
                    radioButton2.Text = dr.GetString(3).ToString();
                    radioButton3.Text = dr.GetString(4).ToString();
                    radioButton4.Text = dr.GetString(5).ToString();

                    if (radioButton1.Checked == true)
                    {
                        if (radioButton1.Text.ToString() == dr.GetString(6).ToString())
                        {
                            count++;
                            label3.Text = "Score =" + count + "";
                        }
                    }
                    if (radioButton2.Checked == true)
                    {
                        if (radioButton2.Text.ToString() == dr.GetString(6).ToString())
                        {
                            count++;
                            label3.Text = "Score =" + count + "";
                        }
                    }
                    if (radioButton3.Checked == true)
                    {
                        if (radioButton3.Text.ToString() == dr.GetString(6).ToString())
                        {
                            count++;
                            label3.Text = "Score =" + count + "";
                        }
                    }
                    if (radioButton4.Checked == true)
                    {
                        if (radioButton4.Text.ToString() == dr.GetString(6).ToString())
                        {
                            count++;
                            label3.Text = "Score =" + count + "";
                        }
                    }
                    i++;
                }
                conn.Close();
            }
        }

        public int counts()
        {
            int a = 1;
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Qno from login where category=" + s1 + "", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow Qno in dt.Rows)
            {
                listBox1.Items.Add(Qno.Field<Int32>(0));
                a = listBox1.Items.Count;
                a++;
            }

            return a;
        }
    }
}
