using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Buyer;

namespace Tawreed.BLL.Services.BuyerService
{
    public interface IBuyerService
    {
        Task<IEnumerable<BuyerResponseDto>> GetAllBuyersAsync();
        Task<BuyerResponseDto> GetBuyerByUserId(Guid userId);
        Task<BuyerResponseDto> CreateBuyer(CreateBuyerDto dto);
        Task<BuyerResponseDto> UpdateBuyer(Guid userId, UpdateBuyerDto dto);
        Task<bool> DeleteBuyerAsync(Guid userId);
    }
}
