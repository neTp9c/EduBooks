using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.ViewModels
{
    public class BookVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; }
        public byte[] Image { get; set; }
        public PublisherVm Publisher { get; set; }
        public IEnumerable<AuthorVm> Authors { get; set; }
    }
}