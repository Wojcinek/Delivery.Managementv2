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
using Delivery.Management.Application.Responses;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryRequests.Handlers.Command
{
    public class CreateDeliveryRequestCommandHandler : IRequestHandler<CreateDeliveryRequestCommand, BaseCommandResponse>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMapper _mapper;
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;

        public CreateDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository, IMapper mapper, IDeliveryAllocationRepository deliveryAllocationRepository, IDeliveryTypeRepository deliveryTypeRepository)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _mapper = mapper;
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _deliveryTypeRepository = deliveryTypeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateDeliveryRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDeliveryRequestDtoValidator(_deliveryAllocationRepository,_deliveryTypeRepository);
            var validationResult = await validator.ValidateAsync(request.DeliveryRequestDto);

            if(validationResult.IsValid == false) 
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else 
            { 
                var deliveryRequest = _mapper.Map<DeliveryRequest>(request.DeliveryRequestDto);
                //deliveryRequest.DeliveryTypeId = request.DeliveryRequestDto.DeliveryTypeId;
                //deliveryRequest.DeliveryAllocationId = request.DeliveryRequestDto.DeliveryAllocationId;
                deliveryRequest = await _deliveryRequestRepository.AddAsync(deliveryRequest);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = deliveryRequest.Id;
            }
            return response;
        }
           
    }
}
