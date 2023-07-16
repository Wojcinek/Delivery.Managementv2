using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Application.Features.DeliveryTypes.Handlers.Queries;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Queries;
using Delivery.Management.Application.Profiles;
using Delivery.Management.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Delivery.Management.UnitTests.Types.Queries
{
    public class GetDeliveryTypeListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDeliveryTypeRepository> _mockRepo;


        public GetDeliveryTypeListRequestHandlerTest()
        {
            _mockRepo = MockDeliveryTypeRepository.GetDeliveryTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetDeliveryTypeListTest()
        {
            var handler = new GetDeliveryTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetDeliveryTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<DeliveryTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
