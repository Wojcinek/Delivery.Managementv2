using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryType.Validators
{
    public class IDeliveryTypeDtoValidator : AbstractValidator<IDeliveryTypeDto>
    {
        public IDeliveryTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
