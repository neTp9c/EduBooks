using Books.Api.ViewModels;
using Books.Entities;

namespace Books.Api.Services
{
    public class PublisherToPublisherVmConverter : IConverter<Publisher, PublisherVm>
    {
        public PublisherVm Convert(Publisher publisher)
        {
            return new PublisherVm
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }
    }
}