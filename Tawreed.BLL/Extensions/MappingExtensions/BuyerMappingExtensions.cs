using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tawreed.BLL.Dtos.Buyer;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Extensions.MappingExtensions
{
    public static class BuyerMappingExtensions
    {
        public static BuyerResponseDto ToDto(this Buyer buyer)
        {
            return new BuyerResponseDto
            {
                UserId = buyer.UserId,
                BusinessName = buyer.BusinessName,
                TaxNumber = buyer.TaxNumber,
                Address = buyer.Address,
                Latitude = buyer.Latitude,
                Longitude = buyer.Longitude,
            };
        }

        public static Buyer ToModel(this CreateBuyerDto dto)
        {
            return new Buyer
            {
                BusinessName = dto.BusinessName,
                TaxNumber = dto.TaxNumber,
                Address = dto.Address,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                RegionId = dto.RegionId
            };
        }

        public static void ApplyUpdate(this UpdateBuyerDto dto, Buyer buyer)
        {
            buyer.Address = dto.Address;
            buyer.Latitude = dto.Latitude;
            buyer.Longitude = dto.Longitude;
            buyer.RegionId = dto.RegionId;
        }
    }
}
