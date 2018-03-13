using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace vol._1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-II3EQ3T;Initial Catalog= Кадры; Integrated Security = True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SqlCommand cmd = new SqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "select sum([Population]) from  Department";
            textBox1.Text = "General number of employees =  " + Convert.ToString(cmd.ExecuteScalar());
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.CommandText = "select NameDepartment from  Department";
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List.Items.Add(reader[0].ToString());
            }

            cnn.Close();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "select NameDepartment from  Department order by Population DESC";
            textBox2.Text = "Most amount of employees - " + Convert.ToString(cmd.ExecuteScalar());
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "insert into  Department values (10,1,3,'Security','Nevsky23', 'sc@trump.com', '5160609')";
            cmd.ExecuteScalar();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnn.Open(); cmd.Connection = cnn;
            cmd.CommandText = "update  Department set Adress = 'Nevsky 153' where [Population] > 10";
            cmd.ExecuteScalar();
            cnn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from  Department where [Population] < 10";
            cmd.ExecuteScalar();
            cnn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "insert into  Department values (3,1," + textBox3.Text + ",'Security','Nevsky 23','sc@trump.com', '5160609')";
            textBox3.Text = "Changes = " + Convert.ToString(cmd.ExecuteNonQuery());
            cnn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from  Department where Population = " + textBox4.Text;
            textBox4.Text = "Deleted = " + Convert.ToString(cmd.ExecuteNonQuery());
            cnn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "create table Day (DayName int primary key, Sales int) ";
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "drop table Day";
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}