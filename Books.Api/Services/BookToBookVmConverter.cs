using Books.Api.ViewModels;
using Books.Entities;
using System.Linq;

namespace Books.Api.Services
{
    public class BookToBookVmConverter : IConverter<Book, BookVm>
    {
        private readonly IConverter<Author, AuthorVm> _authorToAuthorVmConverter;
        private readonly IConverter<Publisher, PublisherVm> _publisherToPublisherVmConverter;

        public BookToBookVmConverter(
            IConverter<Author, AuthorVm> authorToAuthorVmConverter,
            IConverter<Publisher, PublisherVm> publisherToPublisherVmConverter)
        {
            _authorToAuthorVmConverter = authorToAuthorVmConverter;
            _publisherToPublisherVmConverter = publisherToPublisherVmConverter;
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
                //ImageUrl = book.Image,
                Publisher = book.Publisher != null
                    ? _publisherToPublisherVmConverter.Convert(book.Publisher)
                    : null,
                Authors = book.BookAuthors != null
                    ? book.BookAuthors.Select(ba => _authorToAuthorVmConverter.Convert(ba.Author)).ToArray()
                    : null
            };
        }
    }
}