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
    public partial class Form4 : Form
    {
        SageBook sg;
        public Form4(SageBook sageBook)
        {
            InitializeComponent();
            sg = sageBook;

            using (MyDbContext cnt = new MyDbContext())
            {
                comboBox1.DataSource = cnt.Sages.ToList();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Name";
                comboBox2.DataSource = cnt.Books.ToList();
                comboBox2.ValueMember = "Id";
                comboBox2.DisplayMember = "Title";
            }
            if (sg.SageId != -1)
            {
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf((comboBox1.DataSource as List<Sage>).Find(x=>x.Id==sg.SageId));
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf((comboBox2.DataSource as List<Book>).Find(x => x.Id == sg.BookId));
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            sg.SageId = (comboBox1.SelectedItem as Sage).Id;
            sg.BookId = (comboBox2.SelectedItem as Book).Id;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
