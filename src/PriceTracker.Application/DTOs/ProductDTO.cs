using PriceTracker.Domain;

namespace PriceTracker.Application.DTOs
{
    public record ProductDTO(
        Guid productId,
        string Name,
        string ProductURL,
        PriceDTO CurrentPrice,
        DateTime PublishDateTime,
        DateTime? LastUpdate);
}
