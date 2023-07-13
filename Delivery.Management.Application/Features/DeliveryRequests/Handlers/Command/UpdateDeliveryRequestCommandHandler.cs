using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryRequest.Validators;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryRequests.Requests.Command;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Handlers.Command
{
    public class UpdateDeliveryRequestCommandHandler : IRequestHandler<UpdateDeliveryRequestCommand, Unit>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMapper _mapper;
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;

        public UpdateDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository, IMapper mapper, IDeliveryAllocationRepository deliveryAllocationRepository, IDeliveryTypeRepository deliveryTypeRepository)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _mapper = mapper;
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _deliveryTypeRepository = deliveryTypeRepository;
        }
        public async Task<Unit> Handle(UpdateDeliveryRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateDeliveryRequestDtoValidator(_deliveryAllocationRepository, _deliveryTypeRepository);
            var validationResult = await validator.ValidateAsync(request.DeliveryRequestDto);

            if (validationResult.IsValid == false) 
            {
                throw new ValidationException(validationResult);
            }

            var deliveryRequest = await _deliveryRequestRepository.GetAsync(request.DeliveryRequestDto.Id);

            if (request.DeliveryRequestDto != null)
            {
                _mapper.Map(request.DeliveryRequestDto, deliveryRequest);

                await _deliveryRequestRepository.UpdateAsync(deliveryRequest);
            }

            return Unit.Value;
        }
    }
}
