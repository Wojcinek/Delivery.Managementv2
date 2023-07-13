using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryAllocation.Validators
{
    public class IDeliveryAllocationDtoValidator : AbstractValidator<IDeliveryAllocationDto>
    {
        public IDeliveryAllocationDtoValidator()
        {
            RuleFor(p => p.Warehouse)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Section)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
