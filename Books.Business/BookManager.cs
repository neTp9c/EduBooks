using Books.Data;
using Books.Entities;
using Microsoft.EntityFrameworkCore;
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
            return GetEagerBooksQuery()
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return GetEagerBooksQuery()
                .ToList();
        }

        private IQueryable<Book> GetEagerBooksQuery()
        {
            // ef core doesn't support lazy-loading yet
            return _booksContext.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author);
        }
    }
}
