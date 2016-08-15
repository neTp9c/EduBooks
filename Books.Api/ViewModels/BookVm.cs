using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Books.Api.ViewModels
{
    public class BookVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Range(1, 10000)]
        public int PageCount { get; set; }

        [Required]
        [Range(1800, int.MaxValue)]
        public int PublicationYear { get; set; }

        [RegularExpression(@"^(\d{3})?\d{9}(\d|X)$")]
        public string Isbn { get; set; }

        public byte[] Image { get; set; }

        public PublisherVm Publisher { get; set; }

        [MinLength(1)]
        public AuthorVm[] Authors { get; set; }
    }
}