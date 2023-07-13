using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Domain.Common;

namespace Delivery.Management.Domain
{
    public class DeliveryRequest : BaseDomainEntity
    {
        public DeliveryType DeliveryType { get; set; }
        public int DeliveryTypeId { get; set; }
        public DeliveryAllocation DeliveryAllocation { get; set; }
        public int DeliveryAllocationId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string RequestComments { get; set; }

    }
}
