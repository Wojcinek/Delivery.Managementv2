using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Commands;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Commands;
using Delivery.Management.Application.Profiles;
using Delivery.Management.Application.Responses;
using Delivery.Management.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Delivery.Management.UnitTests.Allocations.Commands
{
    public class CreateDeliveryAllocationCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDeliveryAllocationRepository> _mockRepo;
        private readonly CreateDeliveryAllocationDto _deliveryAllocationDto;
        private readonly CreateDeliveryAllocationCommandHandler _handler;

        public CreateDeliveryAllocationCommandHandlerTest()
        {
            _mockRepo = MockDeliveryAllocationRepository.GetDeliveryAllocationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateDeliveryAllocationCommandHandler(_mockRepo.Object, _mapper);

            _deliveryAllocationDto = new CreateDeliveryAllocationDto
            {
                Warehouse = "Test DTO",
                Section = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_Delivery_Allocation_Added()
        {
            var result = await _handler.Handle(new CreateDeliveryAllocationCommand() {DeliveryAllocationDto = _deliveryAllocationDto}, CancellationToken.None);

            var deliveryAllocations = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            deliveryAllocations.Count.ShouldBe(6);
        }


    }

}
