using Books.Api.Services;
using Books.Api.ViewModels.Books;
using Books.Business;
using Books.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Books.Api.Controllers
{
    
    public class BooksController : ApiController
    {
        private readonly BookManager _bookManager;
        private readonly IConverter<Book, BookVM> _bookToVmConverter;

        public BooksController()
        {
            _bookManager = new BookManager();
            _bookToVmConverter = new BookToBookViewModelConverter();
        }

        // GET api/<controller>
        public IEnumerable<BookVM> Get()
        {
            var books = _bookManager.GetBooks().Select(b => _bookToVmConverter.Convert(b));
            return books;
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

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