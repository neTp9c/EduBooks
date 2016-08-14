using Books.Api.ViewModels.Books;
using Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.Services
{
    public class BookToBookViewModelConverter : IConverter<Book, BookVM>
    {
        public BookVM Convert(Book source)
        {
            return new BookVM
            {
                Id = source.Id,
                Title = source.Title,
                PageCount = source.PageCount,
                PublicationYear = source.PublicationYear,
                Isbn = source.Isbn,
                Image = source.Image,
                PublisherId = source.PublisherId,
                AuthorIds = source.BookAuthors.Select(ba => ba.Author.Id)
            };
        }
    }
}