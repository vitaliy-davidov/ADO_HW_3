using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_HW_3
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sage> Sages { get; set; }
        public Book()
        {
            Sages = new List<Sage>();
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
