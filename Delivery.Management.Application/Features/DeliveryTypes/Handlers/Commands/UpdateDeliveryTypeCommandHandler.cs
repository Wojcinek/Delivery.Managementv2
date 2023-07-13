using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryType.Validators;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryTypes.Handlers.Commands
{
    public class UpdateDeliveryTypeCommandHandler : IRequestHandler<UpdateDeliveryTypeCommand, Unit>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IMapper _mapper;

        public UpdateDeliveryTypeCommandHandler(IDeliveryTypeRepository deliveryTypeRepository, IMapper mapper)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDeliveryTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DeliveryTypeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var deliveryType = await _deliveryTypeRepository.GetAsync(request.DeliveryTypeDto.Id);

            _mapper.Map(request.DeliveryTypeDto, deliveryType);

            await _deliveryTypeRepository.UpdateAsync(deliveryType);

            return Unit.Value;
        }
    }
}
