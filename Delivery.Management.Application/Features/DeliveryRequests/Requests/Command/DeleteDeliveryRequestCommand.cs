using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Requests.Command
{
    public class DeleteDeliveryRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
