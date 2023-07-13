using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.DTOs.DeliveryRequest;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Requests.Queries
{
    public class GetDeliveryRequestDetailRequest : IRequest<DeliveryRequestDto>
    {
        public int Id { get; set; }
    }
}
