using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.Buyer;
using Tawreed.BLL.Extensions.MappingExtensions;
using Tawreed.DAL.Migrations;
using Tawreed.DAL.Repository.BuyerRepo;

namespace Tawreed.BLL.Services.BuyerService
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepo _buyerRepo;

        public BuyerService(IBuyerRepo buyerRepo)
        {
            _buyerRepo = buyerRepo;
        }

        public Task<BuyerResponseDto> CreateBuyer(CreateBuyerDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBuyerAsync(Guid userId)
        {
            var buyer = await _buyerRepo.GetByIdAsync(userId);
            if (buyer == null)
            {
                return false;
            }

            var res = await _buyerRepo.DeleteAsync(buyer);

            if (res > 0)
                return true;

            return false;
        }

        public async Task<IEnumerable<BuyerResponseDto>> GetAllBuyersAsync()
        {
            var buyers = await _buyerRepo.GetAllAsync();
            var buyerDtos = buyers.Select(b => b.ToDto());
            return buyerDtos;
        }

        public async Task<BuyerResponseDto> GetBuyerByUserId(Guid userId)
        {
            var buyer = await _buyerRepo.GetByIdAsync(userId);

            if (buyer == null)
                return null;

            var buyerDto = buyer.ToDto();
            return buyerDto;
        }

        public async Task<BuyerResponseDto> UpdateBuyer(Guid userId, UpdateBuyerDto dto)
        {
            var buyer = await _buyerRepo.GetByIdAsync(userId);

            if (buyer == null)
                return null;

            dto.ApplyUpdate(buyer);

            await _buyerRepo.UpdateAsync(buyer);
            return buyer.ToDto();
        }
    }
}
