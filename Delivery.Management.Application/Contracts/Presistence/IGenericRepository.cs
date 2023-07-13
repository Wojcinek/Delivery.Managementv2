﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Management.Application.Contracts.Presistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
