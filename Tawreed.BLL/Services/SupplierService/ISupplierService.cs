using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Buyer;
using Tawreed.BLL.Dtos.Supplier;

namespace Tawreed.BLL.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<SupplierResponseDto> CreateSupplier(CreateSupplierDto dto);
        Task<IEnumerable<SupplierResponseDto>> GetAllSuppliers();
        Task<SupplierResponseDto> GetSupplierByUserId(Guid userId);
        Task<SupplierResponseDto> UpdateSupplier(Guid userId, UpdateSupplierDto dto);
        Task<bool> DeleteSupplierByUserId(Guid userId);
    }
}
