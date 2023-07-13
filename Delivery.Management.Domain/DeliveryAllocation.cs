using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Domain.Common;

namespace Delivery.Management.Domain
{
    public class DeliveryAllocation : BaseDomainEntity
    {
        public string Warehouse { get; set; }
        public string Section { get; set; }
    }
}
