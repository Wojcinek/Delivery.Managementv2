using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryRequest;
using Delivery.Management.Application.Features.DeliveryRequests.Requests.Queries;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Handlers.Queries
{
    public class GetDeliveryRequestDetailRequestHandler : IRequestHandler<GetDeliveryRequestDetailRequest, DeliveryRequestDto>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMapper _mapper;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;

        public GetDeliveryRequestDetailRequestHandler(IDeliveryRequestRepository deliveryRequestRepository, IMapper mapper, IDeliveryTypeRepository deliveryTypeRepository, IDeliveryAllocationRepository deliveryAllocationRepository)
        {

            _deliveryRequestRepository = deliveryRequestRepository;
            _mapper = mapper;

        }
        public async Task<DeliveryRequestDto> Handle(GetDeliveryRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var deliveryRequest = await _deliveryRequestRepository.GetDeliveryRequestWithDetails(request.Id);
            return _mapper.Map<DeliveryRequestDto>(deliveryRequest);
        }
    }
}
