using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Management.Application.DTOs.DeliveryAllocation
{
    public interface IDeliveryAllocationDto
    {
        public string Warehouse { get; set; }
        public string Section { get; set; }
    }
}
