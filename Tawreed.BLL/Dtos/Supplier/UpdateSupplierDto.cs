using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.BLL.Dtos.Supplier
{
    public class UpdateSupplierDto
    {
        [Required]
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string? TaxNumber { get; set; }
        public string? CommercialRegister { get; set; }
    }
}
