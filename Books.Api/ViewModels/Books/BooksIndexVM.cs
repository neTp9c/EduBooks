using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.ViewModels.Books
{
    public class BooksIndexVM
    {

    }

    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; }
        public byte[] Image { get; set; }
        public int PublisherId { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
    }

    public class AuthorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PublisherVM {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}