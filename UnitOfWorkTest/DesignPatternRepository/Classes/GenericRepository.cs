using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;
using UnitOfWorkTest.Data;

namespace UnitOfWorkTest.DesignPatternRepository.Classes
{
    public class GenericRepository<T, Id> : IGenericRepository<T, Id>
    where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MyDbContext myDbContext)
        {
            this._context = myDbContext;
            this._dbSet = myDbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var newEntity = await this._dbSet.AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            return newEntity.Entity;
        }

        public async Task<T> DeleteAsync(Id id)
        {
            var entity = await this._dbSet.FindAsync(id);
            if (entity != null)
            {
                this._dbSet.Remove(entity);
            }
            return entity!;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<T>>(this._dbSet.ToList());
        }

        public Task<T> GetByIdAsync(Id id)
        {
            return Task.FromResult(this._dbSet.Find(id)!);

        }

        public Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = this._dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(updatedEntity.Entity);
        }
    }
}