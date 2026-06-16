using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Dtos.Buyer
{
    public class CreateBuyerDto
    {

        [Required]
        [MaxLength(200)]
        public string BusinessName { get; set; }

        [MaxLength(50)]
        public string? TaxNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }


        public Guid RegionId { get; set; }
    }
}
