using Books.Api.Services;
using Books.Api.ViewModels;
using Books.Business;
using Books.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Books.Api.Controllers
{
    
    public class BooksController : ApiController
    {
        private readonly IBookManager _bookManager;
        private readonly IAuthorManager _authorManager;
        private readonly IConverter<Book, BookVm> _bookToBookVmConverter;
        

        public BooksController(
            IBookManager bookManager,
            IAuthorManager authorManager,
            IConverter<Book, BookVm> bookToBookVmConverter)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
            _bookToBookVmConverter = bookToBookVmConverter;
        }

        // GET api/<controller>
        public IEnumerable<BookVm> Get()
        {
            var books = _bookManager.GetBooks().Select(b => _bookToBookVmConverter.Convert(b));
            return books;
        }

        [Route("api/books/{id}/image")]
        public HttpResponseMessage GetBookImage(int id)
        {
            var book = _bookManager.GetBook(id);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(book.Image);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;
        }

        // POST api/<controller>
        public IHttpActionResult Post(BookVm bookVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book
            {
                Title = bookVm.Title,
                PageCount = bookVm.PageCount,
                Isbn = bookVm.Isbn,
                PublicationYear = bookVm.PublicationYear,
                //Image = bookVm.Image
            };

            if (bookVm.ImageFile != null)
            {
                book.Image = bookVm.ImageFile.Buffer;
            }

            foreach (var authorVm in bookVm.Authors)
            {

                book.BookAuthors.Add(new BookAuthor
                {
                    Author = new Author
                    {
                        FirstName = authorVm.FirstName,
                        LastName = authorVm.LastName
                    }
                });
            }

            if(bookVm.Publisher != null)
            {
                book.Publisher = new Publisher {
                    Name = bookVm.Publisher.Name
                };
            }

            _bookManager.Create(book);

            return Ok(_bookToBookVmConverter.Convert(book));
        }

        // PUT api/<controller>/5
        [HttpPost]
        // MultipartDataMediaFormatter.Infrastructure.FormData formData
        public IHttpActionResult Put(int id, BookVm bookVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _bookManager.GetBook(id);



            // plain book properties
            book.Title = bookVm.Title;
            book.PageCount = bookVm.PageCount;
            book.Isbn = bookVm.Isbn;
            book.PublicationYear = bookVm.PublicationYear;
            


            // image file
            if(bookVm.ImageFile != null)
            {
                book.Image = bookVm.ImageFile.Buffer;
            }
            else if(bookVm.IsNeedRemoveImage)
            {
                book.Image = null;
            }



            // publisher
            if (bookVm.Publisher != null)
            {
                book.Publisher.Name = bookVm.Publisher.Name;
            }
            else
            {
                // should delete publisher or not?
                book.Publisher = null;
            }



            // authors
            var remainingAuthorIds = bookVm.Authors.Where(a => a.Id > 0).Select(a => a.Id).ToList();
            var bookAuthorsToDelete = book.BookAuthors.Where(ba => !remainingAuthorIds.Contains(ba.Author.Id)).ToList();
            foreach (var bookAuthorToDelete in bookAuthorsToDelete)
            {
                // should delete author or not?
                book.BookAuthors.Remove(bookAuthorToDelete);
            }

            foreach (var authorVm in bookVm.Authors)
            {
                Author author = null;
                if (authorVm.Id > 0)
                {
                    author = book.BookAuthors.SingleOrDefault(ba => ba.Author.Id == authorVm.Id).Author;
                }

                if (author == null)
                {
                    author = new Author();
                    book.BookAuthors.Add(new BookAuthor
                    {
                        Author = author
                    });
                }

                author.FirstName = authorVm.FirstName;
                author.LastName = authorVm.LastName;
            }



            // update book
            _bookManager.Update(book);

            return Ok(_bookToBookVmConverter.Convert(book));
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var book = _bookManager.GetBook(id);

            _bookManager.Delete(book);

            return Ok();
        }
    }
}