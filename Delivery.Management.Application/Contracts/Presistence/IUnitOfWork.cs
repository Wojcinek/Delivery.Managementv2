using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Management.Application.Contracts.Presistence
{
    public interface IUnitOfWork : IDisposable
    {
       IDeliveryRequestRepository DeliveryRequestRepository { get; }
       IDeliveryAllocationRepository DeliveryAllocationRepository { get; }
       IDeliveryTypeRepository DeliveryTypeRepository { get; }
        Task Save();
    }
}
