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
    public partial class Form3 : Form
    {
        Sage s;
        public Form3(Sage sage)
        {
            InitializeComponent();
            s = sage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.name = textBox1.Text;
            s.age = dateTimePicker1.Value;
            s.city = textBox3.Text;
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = s.name;
            dateTimePicker1.Value = s.age;
            textBox3.Text = s.city;
        }
    }
}
