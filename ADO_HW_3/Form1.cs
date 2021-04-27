using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_HW_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadData()
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                dataGridView1.DataSource = cnt.Books.Select(x => new { x.Id, x.Title, x.Pages }).ToList();
                dataGridView2.DataSource = cnt.Sages.Select(x => new { x.Id, x.Name, x.Birthday, x.City }).ToList();
                dataGridView3.DataSource = cnt.Sages.SelectMany(x => x.Books.Select(y => new { BookId = y.Id, SageId = x.Id, y.Title,
                     y.Pages, x.Name, x.Birthday, x.City })).ToList();

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView2.Columns["Id"].Visible = false;
                dataGridView3.Columns["SageId"].Visible = false;
                dataGridView3.Columns["BookId"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                Book b = new Book();
                Form2 form = new Form2(b);
                form.ShowDialog();
                cnt.Books.Add(b);
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                var res = cnt.Books.Where(x => x.Id == id).FirstOrDefault();
                cnt.Books.Remove(res);
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                Sage s = new Sage() { Birthday = DateTime.Today};
                Form3 form = new Form3(s);
                form.ShowDialog();
                cnt.Sages.Add(s);
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                int id = Convert.ToInt32(dataGridView2.SelectedCells[0].Value);
                var res = cnt.Sages.Where(x => x.Id == id).FirstOrDefault();
                cnt.Sages.Remove(res);
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                SageBook sg = new SageBook() { SageId = -1 };
                Form4 form = new Form4(sg);
                form.ShowDialog();

                if (cnt.Sages.Find(sg.SageId).Books.Contains(cnt.Books.Find(sg.BookId)))
                {
                    MessageBox.Show("This sage already is author of this book. Thy again.");
                    return;
                }

                cnt.Sages.Find(sg.SageId).Books.Add(cnt.Books.Find(sg.BookId));
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            int index = dataGridView3.SelectedRows[0].Index;
            int idSage = (int)dataGridView3["SageId", index].Value;
            int idBook = (int)dataGridView3["BookId", index].Value;
            using (MyDbContext cnt = new MyDbContext())
            {
                Sage s = cnt.Sages.Find(idSage);
                s.Books.Remove(s.Books.Where(x => x.Id == idBook).FirstOrDefault());
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                var res = cnt.Books.Where(x => x.Id == id).FirstOrDefault();
                Form2 form = new Form2(res);
                form.ShowDialog();
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                int id = Convert.ToInt32(dataGridView2.SelectedCells[0].Value);
                var res = cnt.Sages.Where(x => x.Id == id).FirstOrDefault();
                Form3 form = new Form3(res);
                form.ShowDialog();
                cnt.SaveChanges();
            }
            loadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;


            int index = dataGridView3.SelectedRows[0].Index;
            int idSage = (int)dataGridView3["SageId", index].Value;
            int idBook = (int)dataGridView3["BookId", index].Value;
            SageBook sg = new SageBook() { BookId = idBook, SageId = idSage };
            using (MyDbContext cnt = new MyDbContext())
            {
                cnt.Sages.Load();
                Form4 form = new Form4(sg);
                form.ShowDialog();

                if (idSage == sg.SageId && idBook == sg.BookId)
                    return;

                if(cnt.Sages.Find(sg.SageId).Books.Contains(cnt.Books.Find(sg.BookId)))
                {
                    MessageBox.Show("This sage already is author of this book. Thy again.");
                    return;
                }

                cnt.Sages.Find(idSage).Books.Remove(cnt.Books.Find(idBook));
                cnt.Sages.Find(sg.SageId).Books.Add(cnt.Books.Find(sg.BookId));

                cnt.SaveChanges();
            }
            loadData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
