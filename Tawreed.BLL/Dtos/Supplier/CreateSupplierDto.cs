using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.BLL.Dtos.Supplier
{
    public class CreateSupplierDto
    {
        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string? TaxNumber { get; set; }

        [MaxLength(100)]
        public string? CommercialRegister { get; set; }
    }
}
