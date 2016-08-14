using Books.Data;
using Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public class BookManager
    {
        private readonly BookContext _booksContext;

        public BookManager()
        {
            _booksContext = new BookContext();
        }

        public void Create(Book book)
        {
            _booksContext.Books.Add(book);
        }

        public void Update(Book book)
        {
            _booksContext.Books.Update(book);
        }

        public void Delete(Book book)
        {
            _booksContext.Books.Remove(book);
        }

        public Book GetBook(int id)
        {
            return _booksContext.Books.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksContext.Books.ToList();
        }
    }
}
