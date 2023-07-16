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
    public static class MockDeliveryAllocationRepository
    {
        public static Mock<IDeliveryAllocationRepository> GetDeliveryAllocationRepository()
        {
            var deliveryAllocations = new List<DeliveryAllocation>
            {
                new DeliveryAllocation
                {
                    Id = 101,
                    Warehouse = "Test Standard",
                    Section = "Test 3",
                },
                new DeliveryAllocation
                {
                    Id = 101,
                    Warehouse = "Test Express",
                    Section = "Test 2",
                },
                new DeliveryAllocation
                {
                    Id = 101,
                    Warehouse = "Test Pallete",
                    Section = "Test 5",
                },
                new DeliveryAllocation
                {
                    Id = 101,
                    Warehouse = "Test International By Plane",
                    Section = "Test 14",
                },
                new DeliveryAllocation
                {
                    Id = 101,
                    Warehouse = "Test International By Ship",
                    Section = "Test 45",
                }
            };
            var mockRepo = new Mock<IDeliveryAllocationRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(deliveryAllocations);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<DeliveryAllocation>())).ReturnsAsync((DeliveryAllocation deliveryAllocation) =>
            {
                deliveryAllocations.Add(deliveryAllocation);
                return deliveryAllocation;
            });
            return mockRepo;
        }
    }
}
