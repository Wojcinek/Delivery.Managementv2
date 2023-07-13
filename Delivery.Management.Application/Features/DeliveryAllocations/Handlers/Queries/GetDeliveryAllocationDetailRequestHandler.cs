using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Queries;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Queries
{
    public class GetDeliveryAllocationDetailRequestHandler : IRequestHandler<GetDeliveryAllocationDetailRequest, DeliveryAllocationDto>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IMapper _mapper;

        public GetDeliveryAllocationDetailRequestHandler(IDeliveryAllocationRepository deliveryAllocationRepository, IMapper mapper)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _mapper = mapper;
        }
        public async Task<DeliveryAllocationDto> Handle(GetDeliveryAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var deliveryAllocation = await _deliveryAllocationRepository.GetAsync(request.Id);
            return _mapper.Map<DeliveryAllocationDto>(deliveryAllocation);
        }
    }
}
