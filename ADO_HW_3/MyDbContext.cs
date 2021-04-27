using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_HW_3
{
    public class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public MyDbContext() : base("conStr") { }
        public virtual DbSet<Sage> Sages { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }

    public class MyContextInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        //Початкова ініціалізація
        protected override void Seed(MyDbContext context)
        {
            //При першому створенні БД створемо дві персони
            List<Book> books = new List<Book>();
            List<Sage> sages = new List<Sage>();

            books.Add(new Book() { Title = "grrg", Pages = 20 });
            books.Add(new Book() { Title = "rhrh", Pages = 50 });
            books.Add(new Book() { Title = "rrgrh", Pages = 124 });

            sages.Add(new Sage() { Name = "rgrhhyy", Birthday = DateTime.Now, City = "efgr" });
            sages.Add(new Sage() { Name = "hth", Birthday = DateTime.Now, City = "swdw" });
            sages.Add(new Sage() { Name = "lilik", Birthday = DateTime.Now, City = "frtj" });

            for (int i = 0; i < books.Count-1; i++)
            {
                foreach (var sage in sages)
                {
                    books[i].Sages.Add(sage);
                }
            }

            context.Sages.AddRange(sages);
            context.Books.AddRange(books);

            context.SaveChanges();
        }
    }

}
