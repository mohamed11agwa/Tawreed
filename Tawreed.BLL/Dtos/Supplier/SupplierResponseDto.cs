using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.Supplier
{
    public class SupplierResponseDto
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? TaxNumber { get; set; }
        public string? CommercialRegister { get; set; }
    }
}
