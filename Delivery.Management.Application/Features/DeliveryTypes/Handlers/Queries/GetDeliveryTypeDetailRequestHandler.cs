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
    public class GetDeliveryTypeDetailRequestHandler : IRequestHandler<GetDeliveryTypeDetailRequest, DeliveryTypeDto>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IMapper _mapper;

        public GetDeliveryTypeDetailRequestHandler(IDeliveryTypeRepository deliveryTypeRepository, IMapper mapper)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
            _mapper = mapper;
        }

        public async Task<DeliveryTypeDto> Handle(GetDeliveryTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var deliveryType = await _deliveryTypeRepository.GetAsync(request.Id);
            return _mapper.Map<DeliveryTypeDto>(deliveryType);
        }
    }
}
