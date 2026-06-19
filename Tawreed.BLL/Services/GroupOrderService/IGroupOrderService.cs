using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.BLL.Dtos.GroupOrder;

namespace Tawreed.BLL.Services.GroupOrderService
{
    public interface IGroupOrderService
    {
        Task<IEnumerable<GroupOrderDto>> GetAllAsync();
        Task<GroupOrderDto?> GetByIdAsync(Guid id);
        Task<GroupOrderDto> CreateAsync(CreateGroupOrderDto dto);
        Task<GroupOrderDto?> UpdateAsync(UpdateGroupOrderDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
