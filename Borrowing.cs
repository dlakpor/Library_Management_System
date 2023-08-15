 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System
{
    public partial class Borrowing : Form
    {
        public Borrowing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 BookId = Int64.Parse(textBox1.Text);
            string StudentName = textBox2.Text;
            // Int64 BookName = Int64.Parse(textBox3.Text);
            string DateBorrowed = dateTimePicker2.Text;
            //string ReturnedDate = dateTimePicker1.Text;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            //cmd.CommandText = "insert into Student(StdID,StudentName,StdAge,Department,Contact,Email) values (" + BookId + ",'" + StudentName + "'," + DateBorrowed + ",'" + ReturnedDate + "','" + BookName + "','" + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved");

        }

        private void txt_Add_Click(object sender, EventArgs e)
        {
            txtSName.Clear();
            textBox1.Clear();
            textBox6.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int64 BookID = Int64.Parse(textBox1.Text);
            string StudentName = textBox2.Text;
            //Int64 BookName = Int64.Parse(textBox3.Text);
            string DataBorrowed = dateTimePicker2.Text;
            //string ReturnedDate = dateTimePicker1.Text;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            //cmd.CommandText = "update Student set StudentName='" + StudentName + "',StdAge=" + BookID + ",Department='" + BookName + "',Contact='" + DataBorrowed + "',Email='" + ReturnedDate + "'where StdID=" +  "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int64 Id = Int64.Parse(textBox1.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from Student where StdID=" + Id + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Deleted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                txtSName.Clear();
                textBox1.Clear();
                textBox6.Clear();
                textBox2.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string SName = textBox4.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Student where StudentName='" + SName + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0][4].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    txtSName.Clear();
                    textBox1.Clear();
                    textBox6.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Int64 BookId = Int64.Parse(textBox3.Text);
            string StudentName = txtSName.Text;
            string BorrowDate = dateTimePicker2.Text;
            string BookName = txtBName.Text;
            string StudentEmail = textBox2.Text;
            string StudentContact = textBox6.Text;
            string StudentID= textBox1.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            // Assuming you have a table named "BorrowedBooks" with appropriate columns
            cmd.CommandText = "INSERT INTO BorrowBook(BookID, StudentName, BorrowDate,Email,Contact, StudentID, BookName) VALUES (" + BookId + ", '" + StudentName + "', '" + BorrowDate + "', '"+StudentEmail + "','"+StudentContact+"'," + StudentID + ", '" + BookName + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
           MessageBox.Show("Book Borrowed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from BorrowBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }


}
    
