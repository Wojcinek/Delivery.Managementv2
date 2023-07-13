using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.DTOs.Common;

namespace Delivery.Management.Application.DTOs.DeliveryAllocation
{
    public class DeliveryAllocationDto : BaseDto, IDeliveryAllocationDto
    {
        public string Warehouse { get; set; }
        public string Section { get; set; }

    }
}
