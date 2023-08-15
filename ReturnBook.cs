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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string StudentName = textBox4.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from BorrowBook where BookName='";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                }
                else
                {

                    txtBName.Clear();

                    MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
        ///******Working Search Button****/
        private void button7_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from BorrowBook where StudentName='" + textBox4.Text + "'and ReturnDate is null";
            //2020  and book return date is null
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {

                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           }
        //********Working Refresh Button*********//
        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
        //******Working Search Box***************/
        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox4.Text=="")
            {
                panel3.Visible = false;
                dataGridView2.DataSource = null;
            }
        }
        //************Working Form Load********//
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel3.Visible=false;
            //textBox4.Clear;
        }
             ///******Working Issued Book****/
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-818IMK1\\DEAZSQLEXPRESS01;database=Library Management System;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update BorrowBook set ReturnDate='" + txtRDate.Text + "' where StudentName='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Return Successfully", "Thanks!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReturnBook_Load(this, null);
        }
        //**********Working DataGridView*********//
        string BookName;
        string BorrowDate;
        //Int64 BId;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
               // BId = Int64.Parse(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                BookName = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                BorrowDate = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();

            }

            txtBName.Text = BookName;
            dateTimePicker2.Text = BorrowDate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
    }

   
       
    



