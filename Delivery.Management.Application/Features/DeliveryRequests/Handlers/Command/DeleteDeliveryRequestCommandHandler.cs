using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryRequests.Requests.Command;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Handlers.Command
{
    public class DeleteDeliveryRequestCommandHandler : IRequestHandler<DeleteDeliveryRequestCommand>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMapper _mapper;

        public DeleteDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository, IMapper mapper)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeliveryRequestCommand request, CancellationToken cancellationToken)
        {
            var deliveryRequest = await _deliveryRequestRepository.GetAsync(request.Id);

            if (deliveryRequest == null)
            {
                throw new NotFoundException(nameof(DeliveryRequest), request.Id);
            }

            await _deliveryRequestRepository.DeleteAsync(deliveryRequest);

            return Unit.Value;
        }
    }
}
