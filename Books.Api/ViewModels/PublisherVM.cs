using System.ComponentModel.DataAnnotations;

namespace Books.Api.ViewModels
{
    public class PublisherVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}