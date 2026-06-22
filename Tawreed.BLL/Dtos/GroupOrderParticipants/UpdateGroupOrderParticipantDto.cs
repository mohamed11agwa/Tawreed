using System;
using System.Collections.Generic;
using System.Text;
using Tawreed.DAL.Enums;

namespace Tawreed.BLL.Dtos.GroupOrderParticipants
{
    public class UpdateGroupOrderParticipantDto
    {
        public Guid Id { get; set; }
        public GroupOrderStatus Status { get; set; }
    }
}
