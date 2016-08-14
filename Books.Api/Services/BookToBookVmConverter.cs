using Books.Api.ViewModels;
using Books.Entities;
using System.Linq;

namespace Books.Api.Services
{
    public class BookToBookVmConverter : IConverter<Book, BookVm>
    {
        private readonly IConverter<Author, AuthorVm> _authorToAuthorVmConverter;
        private readonly IConverter<Publisher, PublisherVm> _publisherToPublisherVmConverter;

        public BookToBookVmConverter()
        {
            _authorToAuthorVmConverter = new AuthorToAuthorVmConverter();
            _publisherToPublisherVmConverter = new PublisherToPublisherVmConverter();
        }

        public BookVm Convert(Book book)
        {
            return new BookVm
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                PublicationYear = book.PublicationYear,
                Isbn = book.Isbn,
                Image = book.Image,
                Publisher = book.Publisher != null
                    ? _publisherToPublisherVmConverter.Convert(book.Publisher)
                    : null,
                Authors = book.BookAuthors != null
                    ? book.BookAuthors.Select(ba => _authorToAuthorVmConverter.Convert(ba.Author))
                    : null
            };
        }
    }
}