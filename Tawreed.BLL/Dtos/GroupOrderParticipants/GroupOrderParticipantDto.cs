using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.BLL.Dtos.GroupOrderParticipants
{
    public class GroupOrderParticipantDto
    {
        public Guid Id { get; set; }
        public GroupOrderStatus Status { get; set; }
        public DateTime JoinedAt { get; set; }
        public Guid GroupOrderId { get; set; }
        public Guid BuyerId { get; set; }
    }
}
