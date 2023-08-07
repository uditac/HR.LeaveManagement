﻿using HR.Leavemanagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HRDatabaseContext _context;
        public GenericRepository(HRDatabaseContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(T entity)
        {
           await _context.AddAsync(entity);
           await  _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<T>> GetAsync()
        {
           return _context.Set<T>().FirstAsync(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task IGenericRepository<T>.CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
