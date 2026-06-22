namespace Tawreed.BLL.Contracts.Authentication;

public record RegisterBuyerRequest(
    string FullName,
    string Email,
    string Phone,
    string Password,
    string BusinessName,
    string BusinessType,
    Guid RegionId,
    string Address
);
