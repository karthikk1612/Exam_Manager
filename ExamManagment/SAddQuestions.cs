﻿using System;
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
    public partial class SAddQuestions : Form
    {
        public String query,s2;
        public int count;
        public SAddQuestions(String str)
        {
            InitializeComponent();
            query = "'"+str+"'";
            s2 = str;
            listBox2.Hide();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select staffcategory from login where staffuname="+query+";", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow questioncategory in dt.Rows)
            {
                listBox1.Items.Add(questioncategory.Field<String>(0));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            count = counts();
            String str = "'" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + listBox1.Text.ToString() + "',"+count+"";
            SqlCommand cmd = new SqlCommand(@"insert into login(question,option1,option2,option3,option4,answer,category,Qno) values(" + str + ");", conn);
            cmd.ExecuteNonQuery();
            count++;
            MessageBox.Show("Question Added");
            clear();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffPage s1 = new StaffPage(s2);
            s1.Show();
            this.Hide();
        }

        public int counts()
        {
            int a = 1;
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            String query = "'" + listBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand("select Qno from login where category=" + query + "", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow Qno in dt.Rows)
            {
                listBox2.Items.Add(Qno.Field<Int32>(0));
                a = listBox2.Items.Count;
            }

            return a;
        }
    }
}
