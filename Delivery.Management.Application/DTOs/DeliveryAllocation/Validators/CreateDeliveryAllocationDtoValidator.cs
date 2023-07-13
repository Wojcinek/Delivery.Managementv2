using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryAllocation.Validators
{
    public class CreateDeliveryAllocationDtoValidator : AbstractValidator<CreateDeliveryAllocationDto>
    {
        public CreateDeliveryAllocationDtoValidator()
        {
            Include(new IDeliveryAllocationDtoValidator());
        }
    }
}
