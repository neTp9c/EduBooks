using Books.Data;
using Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public sealed class DataSeed
    {
        private readonly BookContext _bookContext;

        public DataSeed()
        {
            _bookContext = new BookContext();
        }

        public void Seed()
        {
            // seed is not suported for ef core (but it will be in the feature)
            // http://ef.readthedocs.io/en/latest/efcore-vs-ef6/features.html

            if (_bookContext.Books.Any())
            {
                return;
            }

            // authors

            var authorErichGamma = new Author { FirstName = "Erich", LastName = "Gamma" };
            var authorRichardHelm = new Author { FirstName = "Richard", LastName = "Helm" };
            var authorRalphJohnson = new Author { FirstName = "Ralph", LastName = "Johnson" };
            var authorJohnVlissides = new Author { FirstName = "John", LastName = "Vlissides" };

            _bookContext.Authors.Add(authorErichGamma);
            _bookContext.Authors.Add(authorRichardHelm);
            _bookContext.Authors.Add(authorRalphJohnson);
            _bookContext.Authors.Add(authorJohnVlissides);

            _bookContext.SaveChanges();



            // publishers

            var publisherAddisonWesleyProfessional = new Publisher { Name = "Addison-Wesley Professional" };

            _bookContext.Publishers.Add(publisherAddisonWesleyProfessional);

            _bookContext.SaveChanges();



            // books

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    ISBN = "8601419047741",
                    PublicationYear = 1994,
                    PageCount = 395,
                    Publisher = publisherAddisonWesleyProfessional,
                    //PublisherId = publisherAddisonWesleyProfessional.Id,
                    BookAuthors = new List<BookAuthor> {
                        new BookAuthor { Author = authorErichGamma },
                        new BookAuthor { Author = authorRichardHelm },
                        new BookAuthor { Author = authorRalphJohnson },
                        new BookAuthor { Author = authorJohnVlissides }
                    }
                }
            };

            _bookContext.Books.AddRange(books);

            _bookContext.SaveChanges();
        }
    }
}
