using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.BLL.Dtos.GroupOrder
{
    public class GroupOrderDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DeadlineAt { get; set; }
        public GroupOrderStatus Status { get; set; }
        public Guid CreatorId { get; set; }
        public Guid RegionId { get; set; }
    }
}
