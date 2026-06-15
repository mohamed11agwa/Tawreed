using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.Reigon
{
    public class RegionResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }


    public class CreateRegionDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }

    public class UpdateRegionDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

}
