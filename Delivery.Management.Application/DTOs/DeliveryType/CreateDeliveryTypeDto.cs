using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.DTOs.Common;

namespace Delivery.Management.Application.DTOs.DeliveryType
{
    public class CreateDeliveryTypeDto : IDeliveryTypeDto
    {
        public string Name { get; set; }
    }
}
