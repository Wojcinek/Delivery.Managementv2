using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Domain;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryRequest.Validators
{
    public class CreateDeliveryRequestDtoValidator : AbstractValidator<CreateDeliveryRequestDto>
    {

        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;

        public CreateDeliveryRequestDtoValidator(IDeliveryAllocationRepository deliveryAllocationRepository, IDeliveryTypeRepository deliveryTypeRepository)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _deliveryTypeRepository = deliveryTypeRepository;

            Include(new IDeliveryRequestDtoValidator(_deliveryAllocationRepository,_deliveryTypeRepository));
        }
     }
}
