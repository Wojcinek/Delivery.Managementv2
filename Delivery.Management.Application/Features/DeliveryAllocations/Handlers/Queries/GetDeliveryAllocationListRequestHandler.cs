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
    public class GetDeliveryAllocationListRequestHandler : IRequestHandler<GetDeliveryAllocationListRequest, List<DeliveryAllocationDto>>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IMapper _mapper;

        public GetDeliveryAllocationListRequestHandler(IDeliveryAllocationRepository deliveryAllocationRepository, IMapper mapper)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<DeliveryAllocationDto>> Handle(GetDeliveryAllocationListRequest request, CancellationToken cancellationToken)
        {
            var deliveryAllocation = await _deliveryAllocationRepository.GetAllAsync();
            return _mapper.Map<List<DeliveryAllocationDto>>(deliveryAllocation);
        }
    }
}
