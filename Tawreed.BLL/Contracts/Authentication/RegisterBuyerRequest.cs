
namespace Tawreed.BLL.Contracts.Authentication;

public record RegisterBuyerRequest(
    string FullName,
    string Email,
    string Phone,
    string Password,
    string PreferredLang,
    string BusinessName,
    string BusinessType,
    string? TaxNumber,
    decimal RatingAvg,
    string? Address,
    decimal? Latitude,
    decimal? Longitude,
    Guid RegionId
);
