using System.ComponentModel.DataAnnotations;

namespace Books.Api.ViewModels
{
    public class AuthorVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}