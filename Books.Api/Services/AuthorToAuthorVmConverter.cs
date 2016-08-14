using Books.Api.ViewModels;
using Books.Entities;

namespace Books.Api.Services
{
    public class AuthorToAuthorVmConverter : IConverter<Author, AuthorVm>
    {
        public AuthorVm Convert(Author author)
        {
            return new AuthorVm
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}