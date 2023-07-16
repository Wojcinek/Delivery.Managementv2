using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Domain;
using Moq;

namespace Delivery.Management.UnitTests.Mocks
{
    public class MockDeliveryTypeRepository
    {
        public static Mock<IDeliveryTypeRepository> GetDeliveryTypeRepository()
        {
            var deliveryTypes = new List<DeliveryType>
            {
                new DeliveryType
                {
                    Id = 1001,
                    Name = "test 1"
                },
                new DeliveryType
                {
                    Id = 1002,
                    Name = "test 2"
                },
                new DeliveryType
                {
                    Id = 1003,
                    Name = "test 3"
                },

            };
            var mockRepo = new Mock<IDeliveryTypeRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(deliveryTypes);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<DeliveryType>())).ReturnsAsync((DeliveryType deliveryType) =>
            {
                deliveryTypes.Add(deliveryType);
                return deliveryType;
            });
            return mockRepo;
        }
    }
}
