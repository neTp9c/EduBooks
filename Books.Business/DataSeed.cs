using Books.Data;
using Books.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Books.Business
{
    public sealed class DataSeed
    {
        public void Seed()
        {
            using (var bookContext = new BookContext())
            {
                // seed is not suported for ef core (but it will be in the feature)
                // http://ef.readthedocs.io/en/latest/efcore-vs-ef6/features.html

                if (bookContext.Books.Any())
                {
                    return;
                }

                // authors

                var authorErichGamma = new Author { FirstName = "Erich", LastName = "Gamma" };
                var authorRichardHelm = new Author { FirstName = "Richard", LastName = "Helm" };
                var authorRalphJohnson = new Author { FirstName = "Ralph", LastName = "Johnson" };
                var authorJohnVlissides = new Author { FirstName = "John", LastName = "Vlissides" };

                bookContext.Authors.Add(authorErichGamma);
                bookContext.Authors.Add(authorRichardHelm);
                bookContext.Authors.Add(authorRalphJohnson);
                bookContext.Authors.Add(authorJohnVlissides);

                bookContext.SaveChanges();



                // publishers

                var publisherAddisonWesleyProfessional = new Publisher { Name = "Addison-Wesley Professional" };

                bookContext.Publishers.Add(publisherAddisonWesleyProfessional);

                bookContext.SaveChanges();



                // books

                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                        Isbn = "8601419047741",
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

                bookContext.Books.AddRange(books);

                bookContext.SaveChanges();
            }
        }
    }
}
