using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.Buyer
{
    public class PatchBuyerDto
    {
        public string? Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Guid? RegionId { get; set; }
    }
}
