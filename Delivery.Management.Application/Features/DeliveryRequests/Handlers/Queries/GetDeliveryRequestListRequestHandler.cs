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
    public class GetDeliveryRequestListRequestHandler : IRequestHandler<GetDeliveryRequestListRequest, List<DeliveryRequestListDto>>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMapper _mapper;

        public GetDeliveryRequestListRequestHandler(IDeliveryRequestRepository deliveryRequestRepository, IMapper mapper)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<DeliveryRequestListDto>> Handle(GetDeliveryRequestListRequest request, CancellationToken cancellationToken)
        {
            var deliveryRequest = await _deliveryRequestRepository.GetDeliveryRequestWithDetails();
            return _mapper.Map<List<DeliveryRequestListDto>>(deliveryRequest);
        }
    }
}
