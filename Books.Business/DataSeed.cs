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
                var robertMartin = new Author { FirstName = "Robert", LastName = "C. Martin" };
                var jeffreyRichter = new Author { FirstName = " Jeffrey", LastName = "Richter" };

                bookContext.Authors.Add(authorErichGamma);
                bookContext.Authors.Add(authorRichardHelm);
                bookContext.Authors.Add(authorRalphJohnson);
                bookContext.Authors.Add(authorJohnVlissides);

                bookContext.SaveChanges();



                // publishers

                var publisherAddisonWesleyProfessional = new Publisher { Name = "Addison-Wesley Professional" };
                var publisherPrenticeHall = new Publisher { Name = "Prentice Hall" };
                var microsoftPress = new Publisher { Name = "Microsoft Press" };

                bookContext.Publishers.Add(publisherAddisonWesleyProfessional);
                bookContext.Publishers.Add(publisherPrenticeHall);
                bookContext.Publishers.Add(microsoftPress);

                bookContext.SaveChanges();



                // books

                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Design Patterns: Gang Of Four",
                        Isbn = "8601419047741",
                        PublicationYear = 1994,
                        PageCount = 395,
                        Publisher = publisherAddisonWesleyProfessional,
                        BookAuthors = new List<BookAuthor> {
                            new BookAuthor { Author = authorErichGamma },
                            new BookAuthor { Author = authorRichardHelm },
                            new BookAuthor { Author = authorRalphJohnson },
                            new BookAuthor { Author = authorJohnVlissides }
                        }
                    },
                    new Book
                    {
                        Title = "Clean Code",
                        Isbn="9780132350884",
                        PublicationYear = 2008,
                        PageCount = 464,
                        Publisher = publisherAddisonWesleyProfessional,
                        BookAuthors = new List<BookAuthor> {
                            new BookAuthor { Author = robertMartin }
                        }
                    },
                    new Book
                    {
                        Title = "CLR via C#",
                        Isbn="9780735667457",
                        PublicationYear = 2012,
                        PageCount = 896,
                        Publisher = microsoftPress,
                        BookAuthors = new List<BookAuthor> {
                            new BookAuthor { Author = jeffreyRichter }
                        }
                    },
                   
                };
                
                bookContext.Books.AddRange(books);

                bookContext.SaveChanges();
            }
        }
    }
}
