using System.ComponentModel.DataAnnotations;

namespace Tawreed.BLL.Dtos.Supplier
{
    public class CreateSupplierDto
    {
        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? TaxNumber { get; set; }

    }
}
