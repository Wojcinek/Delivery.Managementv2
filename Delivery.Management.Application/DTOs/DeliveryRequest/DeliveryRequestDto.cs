using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.DTOs.Common;
using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.DTOs.DeliveryType;

namespace Delivery.Management.Application.DTOs.DeliveryRequest
{
    public class DeliveryRequestDto : BaseDto, IDeliveryRequestDto
    {
        public DeliveryTypeDto DeliveryType { get; set; }
        public int DeliveryTypeId { get; set; }
        public DeliveryAllocationDto DeliveryAllocation { get; set; }
        public int DeliveryAllocationId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string RequestComments { get; set; }

    }
}
