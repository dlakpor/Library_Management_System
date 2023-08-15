using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Students stu = new Students();
            stu.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Borrowing borrowing = new Borrowing();
            borrowing.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();
             returnBook.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
