using Books.Business;
using Books.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Books.Api.Controllers
{
    
    public class BooksController : ApiController
    {
        private readonly BookManager _bookManager;

        public BooksController()
        {
            _bookManager = new BookManager();
        }

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            var books = _bookManager.GetBooks();
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