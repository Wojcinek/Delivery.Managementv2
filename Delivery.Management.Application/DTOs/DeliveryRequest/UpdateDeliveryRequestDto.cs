using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.DTOs.Common;

namespace Delivery.Management.Application.DTOs.DeliveryRequest
{
    public class UpdateDeliveryRequestDto : BaseDto, IDeliveryRequestDto
    {
        public int DeliveryTypeId { get; set; }
        public int DeliveryAllocationId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string RequestComments { get; set; }
    }
}
