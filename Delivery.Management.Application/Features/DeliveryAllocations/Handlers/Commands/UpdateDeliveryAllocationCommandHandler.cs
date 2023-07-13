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
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Commands
{
    public class UpdateDeliveryAllocationCommandHandler : IRequestHandler<UpdateDeliveryAllocationCommand, Unit>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateDeliveryAllocationCommandHandler(IDeliveryAllocationRepository deliveryAllocationRepository, IMapper mapper)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDeliveryAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDeliveryAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DeliveryAllocationDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var deliveryAllocation = await _deliveryAllocationRepository.GetAsync(request.DeliveryAllocationDto.Id);

            _mapper.Map(request.DeliveryAllocationDto, deliveryAllocation);

            await _deliveryAllocationRepository.UpdateAsync(deliveryAllocation);

            return Unit.Value;
        }
    }
}
