using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Delivery.Management.Application.DTOs.DeliveryType.Validators
{
    public class CreateDeliveryTypeDtoValidator : AbstractValidator<CreateDeliveryTypeDto>
    {
        public CreateDeliveryTypeDtoValidator()
        {
            Include(new IDeliveryTypeDtoValidator());
        }
    }
}
