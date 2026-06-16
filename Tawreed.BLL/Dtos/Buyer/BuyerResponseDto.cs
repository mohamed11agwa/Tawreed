using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.Buyer
{
    public class BuyerResponseDto
    {
        public Guid UserId { get; set; }
        public string BusinessName { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
