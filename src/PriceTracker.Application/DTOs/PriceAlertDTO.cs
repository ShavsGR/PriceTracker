

using PriceTracker.Domain;

namespace PriceTracker.Application.DTOs
{
    public record PriceAlertDTO(
        Guid AlertId,
        Guid ProductId,
        Guid UserId,
        PriceDTO TargetPrice,
        bool Active,
        DateTime? AlertDate,
        DateTime PublishDate);
}
