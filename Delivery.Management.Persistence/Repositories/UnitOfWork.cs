using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;

namespace Delivery.Management.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryManagementDbContext _context;
        private IDeliveryAllocationRepository _deliveryAllocationRepository;
        private IDeliveryRequestRepository _deliveryRequestRepository;
        private IDeliveryTypeRepository _deliveryTypeRepository;
        public UnitOfWork(DeliveryManagementDbContext context)
        {
            _context = context;
        }

        public IDeliveryRequestRepository DeliveryRequestRepository => _deliveryRequestRepository ??= new DeliveryRequestRepository(_context);

        public IDeliveryAllocationRepository DeliveryAllocationRepository => _deliveryAllocationRepository ??= new DeliveryAllocationRepository(_context);

        public IDeliveryTypeRepository DeliveryTypeRepository => _deliveryTypeRepository ??= new DeliveryTypeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
