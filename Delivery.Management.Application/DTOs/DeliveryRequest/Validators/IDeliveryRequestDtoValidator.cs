using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryRequest.Validators
{
    public class IDeliveryRequestDtoValidator : AbstractValidator<IDeliveryRequestDto>
    {
        private readonly IDeliveryAllocationRepository _deliveryAllocationRepository;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;

        public IDeliveryRequestDtoValidator(IDeliveryAllocationRepository deliveryAllocationRepository, IDeliveryTypeRepository deliveryTypeRepository)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
            _deliveryTypeRepository = deliveryTypeRepository;

            RuleFor(p => p.City)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Street)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.RequestComments)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ZipCode)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                      .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.HouseNumber)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull();


            RuleFor(p => p.DeliveryAllocationId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var deliveryAllocationExists = await _deliveryAllocationRepository.Exists(id);
                        return !deliveryAllocationExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.DeliveryTypeId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var deliveryTypeExists = await _deliveryTypeRepository.Exists(id);
                        return !deliveryTypeExists;
                    })
                    .WithMessage("{PropertyName} does not exist.");

        }
    }
}
