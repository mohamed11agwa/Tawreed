using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tawreed.BLL.Dtos.Buyer
{
    public class UpdateBuyerDto
    {
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }


        public Guid RegionId { get; set; }
    }
}
