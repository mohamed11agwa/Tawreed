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

public record RegisterSupplierRequest(
    string FullName,
    string Email,
    string Phone,
    string Password,
    string CompanyName,
    string? TaxId,
    string? CommercialRegister,
    List<Guid> RegionIds,
    List<Guid> CategoryIds
);
