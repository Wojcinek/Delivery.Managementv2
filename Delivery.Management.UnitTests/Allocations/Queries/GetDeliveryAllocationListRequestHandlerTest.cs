using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.Features.DeliveryAllocations.Handlers.Queries;
using Delivery.Management.Application.Profiles;
using Delivery.Management.UnitTests.Mocks;
using Moq;
using Xunit;
using Shouldly;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Queries;
using Delivery.Management.Application.Contracts.Presistence;

namespace Delivery.Management.UnitTests.Allocations.Queries
{
    public class GetDeliveryAllocationListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDeliveryAllocationRepository> _mockRepo;

        public GetDeliveryAllocationListRequestHandlerTest()
        {
            _mockRepo = MockDeliveryAllocationRepository.GetDeliveryAllocationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetDeliveryAllocationListTest()
        {
            var handler = new GetDeliveryAllocationListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetDeliveryAllocationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<DeliveryAllocationDto>>();

            result.Count.ShouldBe(5);
        }
    }
}
