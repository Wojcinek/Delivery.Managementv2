using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryAllocation.Validators;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Commands;
using Delivery.Management.Application.Responses;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Commands
{
    public class CreateDeliveryAllocationCommandHandler : IRequestHandler<CreateDeliveryAllocationCommand, BaseCommandResponse>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IMapper _mapper;

        public CreateDeliveryAllocationCommandHandler(IDeliveryAllocationRepository deliveryAllocationRepository, IMapper mapper)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDeliveryAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDeliveryAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DeliveryAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var deliveryAllocation = _mapper.Map<DeliveryAllocation>(request.DeliveryAllocationDto);

                deliveryAllocation = await _deliveryAllocationRepository.AddAsync(deliveryAllocation);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = deliveryAllocation.Id;
            }
            return response;
        }
    }
}
