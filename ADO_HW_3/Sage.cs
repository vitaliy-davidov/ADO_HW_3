using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_HW_3
{
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public Sage()
        {
            Books = new List<Book>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
