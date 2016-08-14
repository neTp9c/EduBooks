using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int PageCount { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public byte[] Image { get; set; }


        public virtual ICollection<Publisher> Publisher { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
