using Books.Api.Services;
using Books.Api.ViewModels;
using Books.Business;
using Books.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Books.Api.Controllers
{
    
    public class BooksController : ApiController
    {
        private readonly IBookManager _bookManager;
        private readonly IConverter<Book, BookVm> _bookToBookVmConverter;

        public BooksController(
            IBookManager bookManager,
            IConverter<Book, BookVm> bookToBookVmConverter)
        {
            _bookManager = bookManager;
            _bookToBookVmConverter = bookToBookVmConverter;
        }

        // GET api/<controller>
        public IEnumerable<BookVm> Get()
        {
            var books = _bookManager.GetBooks().Select(b => _bookToBookVmConverter.Convert(b));
            return books;
        }

        public string Get(int id)
        {
            return "value";
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
                Image = bookVm.Image
            };

            _bookManager.Create(book);

            return Ok(_bookToBookVmConverter.Convert(book));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}