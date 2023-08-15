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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace Library_Management_System
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 Id = Int64.Parse(textBox1.Text);
            string StudentName=textBox2.Text;
            Int64 StudentAge =Int64.Parse(textBox3.Text);
            string Department = textBox4.Text;
            string Contact = textBox5.Text;
            string Email = textBox6.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into Student(StdID,StudentName,StdAge,Department,Contact,Email) values (" + Id + ",'" + StudentName + "'," + StudentAge + ",'" + Department + "','" + Contact + "','" + Email + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved");

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
        int StdId;
        Int64 rowId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                StdId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student where StdID="+StdId+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
           textBox3.Text= ds.Tables[0].Rows[0][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dataGridView1.Visible= true;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int64 Id = Int64.Parse(textBox1.Text);
            string StudentName = textBox2.Text;
            Int64 StudentAge = Int64.Parse(textBox3.Text);
            string Department = textBox4.Text;
            string Contact = textBox5.Text;
            string Email = textBox6.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Student set StudentName='"+StudentName+"',StdAge="+StudentAge+",Department='"+Department+"',Contact='"+Contact+"',Email='"+Email+ "'where StdID="+Id+"";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
 