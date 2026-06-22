using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.BLL.Dtos.GroupOrderParticipants
{
    public class CreateGroupOrderParticipantDto
    {
        public Guid GroupOrderId { get; set; }
        public Guid BuyerId { get; set; }
    }
}
