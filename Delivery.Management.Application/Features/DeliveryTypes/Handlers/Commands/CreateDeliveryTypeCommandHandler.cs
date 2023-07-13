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
using Delivery.Management.Application.Responses;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryTypes.Handlers.Commands
{
    public class CreateDeliveryTypeCommandHandler : IRequestHandler<CreateDeliveryTypeCommand, BaseCommandResponse>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IMapper _mapper;

        public CreateDeliveryTypeCommandHandler(IDeliveryTypeRepository deliveryTypeRepository, IMapper mapper)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDeliveryTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DeliveryTypeDto);

            if (validationResult.IsValid == false) 
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var deliveryType = _mapper.Map<DeliveryType>(request.DeliveryTypeDto);

                deliveryType = await _deliveryTypeRepository.AddAsync(deliveryType);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = deliveryType.Id;
            }
           
            return response;
            
        }
    }
}
