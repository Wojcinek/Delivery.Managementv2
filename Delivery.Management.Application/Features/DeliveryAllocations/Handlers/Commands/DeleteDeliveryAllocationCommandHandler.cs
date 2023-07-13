using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Commands;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Commands
{
    public class DeleteDeliveryAllocationCommandHandler : IRequestHandler<DeleteDeliveryAllocationCommand>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteDeliveryAllocationCommandHandler(IDeliveryAllocationRepository deliveryAllocationRepository, IMapper mapper)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeliveryAllocationCommand request, CancellationToken cancellationToken)
        {
            var deliveryAllocation = await _deliveryAllocationRepository.GetAsync(request.Id);

            if (deliveryAllocation == null)
            {
                throw new NotFoundException(nameof(DeliveryAllocation), request.Id);
            }

            await _deliveryAllocationRepository.DeleteAsync(deliveryAllocation);

            return Unit.Value;
        }
    }
}
