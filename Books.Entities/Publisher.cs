﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}
