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

            using (DataClasses1DataContext cnt = new DataClasses1DataContext())
            {
                comboBox1.Items.AddRange(cnt.Sage.Select(x => new SageToString() { Sage = x }).ToArray());
                comboBox2.Items.AddRange(cnt.Book.Select(x => new BookToString() { Book = x }).ToArray());
            }

            if (sg.Sage != null)
            {
                comboBox1.SelectedIndex = comboBox1.FindString(sg.Sage.name);
                comboBox2.SelectedIndex = comboBox2.FindString(sg.Book.title);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sg.idSage = (comboBox1.SelectedItem as SageToString).Sage.id;
            sg.idBook = (comboBox2.SelectedItem as BookToString).Book.id;
            Close();
        }
    }
}
