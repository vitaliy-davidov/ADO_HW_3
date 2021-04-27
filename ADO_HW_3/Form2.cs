using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_HW_3
{
    public partial class Form2 : Form
    {
        private Book b;
        public Form2(Book book)
        {
            InitializeComponent();
            b = book;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.Title = textBox1.Text;
            b.Pages = Int32.Parse(textBox2.Text);
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = b.Title;
            textBox2.Text = b.Pages.ToString();
        }
    }
}
