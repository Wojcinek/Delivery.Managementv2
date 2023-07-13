using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryAllocation.Validators
{
    public class UpdateDeliveryAllocationDtoValidator : AbstractValidator<DeliveryAllocationDto>
    {
        public UpdateDeliveryAllocationDtoValidator()
        {
            Include(new IDeliveryAllocationDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
