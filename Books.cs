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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Int64 BId = Int64.Parse(textBox1.Text);
            string BName = textBox2.Text;
            string BAuthor = textBox3.Text;
            string Publisher = textBox4.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into Book(BookID,BookName,BookAuthor,Publisher) values (" + BId + ",'" + BName + "','" + BAuthor + "','" + Publisher + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
             dataGridView1.Visible = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int64 BId = Int64.Parse(textBox1.Text);
            string BName = textBox2.Text;
            string BAuthor = textBox3.Text;
            string Publisher = textBox4.Text;
           

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Book set BookName='" + BName + "',BookAuthor='"+ BAuthor + "',Publisher='" + Publisher + "' where BookID=" + BId+ "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Book Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Book";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int64 BId = Int64.Parse(textBox1.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from Book where BookID=" + BId + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Book Deleted");
        }
        int BId;
        Int64 rowId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Book where BookID=" + BId + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
           
        }
    
    }

}
