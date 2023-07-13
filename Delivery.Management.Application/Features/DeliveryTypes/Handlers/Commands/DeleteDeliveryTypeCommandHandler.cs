using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.Exceptions;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using Delivery.Management.Domain;
using MediatR;

namespace Delivery.Management.Application.Features.DeliveryTypes.Handlers.Commands
{
    public class DeleteDeliveryTypeCommandHandler : IRequestHandler<DeleteDeliveryTypeCommand>
    {
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly IMapper _mapper;

        public DeleteDeliveryTypeCommandHandler(IDeliveryTypeRepository deliveryTypeRepository, IMapper mapper)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var deliveryType = await _deliveryTypeRepository.GetAsync(request.Id);

            if (deliveryType == null)
            {
                throw new NotFoundException(nameof(DeliveryType), request.Id);
            }

            await _deliveryTypeRepository.DeleteAsync(deliveryType);

            return Unit.Value;
        }
    }
}
