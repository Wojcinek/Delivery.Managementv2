using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Queries;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryTypes.Handlers.Queries
{
    public class GetDeliveryTypeListRequestHandler : IRequestHandler<GetDeliveryTypeListRequest, List<DeliveryTypeDto>>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IMapper _mapper;

        public GetDeliveryTypeListRequestHandler(IDeliveryTypeRepository deliveryTypeRepository, IMapper mapper)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<DeliveryTypeDto>> Handle(GetDeliveryTypeListRequest request, CancellationToken cancellationToken)
        {
            var deliveryTypes = await _deliveryTypeRepository.GetAllAsync();
            return _mapper.Map<List<DeliveryTypeDto>>(deliveryTypes);
        }
    }
}
