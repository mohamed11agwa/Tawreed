using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.GroupOrder
{
    public class CreateGroupOrderDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DeadlineAt { get; set; }
        public Guid CreatorId { get; set; }
        public Guid RegionId { get; set; }
    }
}
