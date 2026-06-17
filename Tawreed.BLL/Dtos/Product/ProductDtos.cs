using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.BLL.Dtos.Product
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }

    // ── Requests ─────────────────────────────────────────────────────────────

    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UnitOfMeasure Unit { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UnitOfMeasure? Unit { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class PatchProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public UnitOfMeasure? Unit { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
