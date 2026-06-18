namespace Tawreed.BLL.Contracts.Authentication;

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
