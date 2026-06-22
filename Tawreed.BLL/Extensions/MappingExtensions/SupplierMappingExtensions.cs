using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Supplier;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class SupplierMappingExtensions
    {
        public static SupplierResponseDto ToDto(this Supplier supplier)
        {
            return new SupplierResponseDto
            {
                UserId = supplier.UserId,
                CompanyName = supplier.CompanyName,
                TaxNumber = supplier.TaxNumber,
            };
        }

        public static Supplier ToModel(this CreateSupplierDto dto)
        {
            return new Supplier
            {
                CompanyName = dto.CompanyName,
                TaxNumber = dto.TaxNumber,
            };
        }

        public static void ApplyUpdates(this UpdateSupplierDto dto, Supplier supplier)
        {
            supplier.CompanyName = dto.CompanyName;
            supplier.TaxNumber = dto.TaxNumber;
        }

    }
}
