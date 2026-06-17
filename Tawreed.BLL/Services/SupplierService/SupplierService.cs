using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Supplier;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Repository.Supplier_Repo;

namespace Tawreed.BLL.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;

        public SupplierService(ISupplierRepo supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public Task<SupplierResponseDto> CreateSupplier(CreateSupplierDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSupplierByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SupplierResponseDto>> GetAllSuppliers()
        {
            var suppliers = await _supplierRepo.GetAllAsync();
            var supplierDtos = suppliers.Select(s => s.ToDto());
            return supplierDtos;
        }

        public async Task<SupplierResponseDto> GetSupplierByUserId(Guid userId)
        {
            var supplier = await _supplierRepo.GetByIdAsync(userId);

            if (supplier == null)
                return null;

            var supplierDto = supplier.ToDto();
            return supplierDto;
        }

        public async Task<SupplierResponseDto> UpdateSupplier(Guid userId, UpdateSupplierDto dto)
        {
            var supplier = await _supplierRepo.GetByIdAsync(userId);

            if (supplier == null)
                return null;

            dto.ApplyUpdates(supplier);
            await _supplierRepo.UpdateAsync(supplier);
            return supplier.ToDto();
        }
    }
}
