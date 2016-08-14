using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.ViewModels
{
    public class AuthorVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}