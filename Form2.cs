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




namespace Student_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C: \Users\hp\source\repos\Student Management System\Student Management System\Database1.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = textBox1.Text;
            string name= textBox2.Text;
            string dob = textBox3.Text;
            string address = textBox4.Text;
            string contact = textBox5.Text;

            //add button code
            string sql_insert = "INSERT INTO student(ID,Name<DOB,Address,Contact)VALUES("+id+","+name+","+dob+","+address+","+contact+")";
                SqlCommand cmd = new SqlCommand(sql_insert,con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved Successfully");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //search button code
            con.Open();
            String id = textBox1.Text;

            String sql_search = "SELECT * FROM student WHERE ID =" + id + "";

            SqlCommand cmd = new SqlCommand(sql_search, con);

            SqlDataReader r = cmd.ExecuteReader();

            if(r.Read())
            {
                textBox2.Text = r[1].ToString();
                textBox3.Text = r[2].ToString();
                textBox4.Text = r[4].ToString();
                textBox5.Text = r[5].ToString();
                MessageBox.Show("Found Successfully");

            }
            else
            {

                textBox2.Text = null;
                textBox2.Text = null;
                textBox2.Text = null;
                textBox2.Text = null;
                MessageBox.Show("NOT FOUND");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string dob = textBox3.Text;
            string address = textBox4.Text;
            string contact = textBox5.Text;

            //update button code
            string sql_update = "UPDATE student SET Name =  "+ name +",DOB =" +dob +",Address =" +address+",Contact=" +contact + "WHERE ID = "+id+"";
            SqlCommand cmd = new SqlCommand(sql_update, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");
            con.Close();
        }
    }
}
