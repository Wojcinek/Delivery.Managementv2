using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Commands;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Commands;
using Delivery.Management.Application.Features.DeliveryTypes.Handlers.Commands;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using Delivery.Management.Application.Profiles;
using Delivery.Management.Application.Responses;
using Delivery.Management.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Delivery.Management.UnitTests.Types.Commands
{
    public class CreateDeliveryTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDeliveryTypeRepository> _mockRepo;
        private readonly CreateDeliveryTypeDto _deliveryTypeDto;
        private readonly CreateDeliveryTypeCommandHandler _handler;

        public CreateDeliveryTypeCommandHandlerTest()
        {
            _mockRepo = MockDeliveryTypeRepository.GetDeliveryTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateDeliveryTypeCommandHandler(_mockRepo.Object, _mapper);

            _deliveryTypeDto = new CreateDeliveryTypeDto
            {
                Name = "Test DTO",
            };
        }

        [Fact]
        public async Task Valid_Delivery_Type_Added()
        {
            var result = await _handler.Handle(new CreateDeliveryTypeCommand() { DeliveryTypeDto = _deliveryTypeDto }, CancellationToken.None);

            var deliveryAllocations = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            deliveryAllocations.Count.ShouldBe(4);
        }


    }
}
