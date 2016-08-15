using Books.Data;
using Books.Entities;

namespace Books.Business
{
    public interface IAuthorManager
    {
        void Create(Author author);
        void Delete(Author author);
    }

    public class AuthorManager : IAuthorManager
    {
        private readonly BookContext _booksContext;

        public AuthorManager(BookContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void Create(Author author)
        {
            _booksContext.Authors.Add(author);
            _booksContext.SaveChanges();
        }

        public void Delete(Author author)
        {
            _booksContext.Authors.Remove(author);
            _booksContext.SaveChanges();
        }
    }
}
