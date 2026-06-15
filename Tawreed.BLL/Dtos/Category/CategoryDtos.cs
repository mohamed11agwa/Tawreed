using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.BLL.Dtos.Category
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    // ── Requests ─────────────────────────────────────────────────────────────

    public class CreateCategoryDto
    {
        public CategoryName Name { get; set; }
    }

    public class UpdateCategoryDto
    {
        public CategoryName Name { get; set; }
    }
  
}
