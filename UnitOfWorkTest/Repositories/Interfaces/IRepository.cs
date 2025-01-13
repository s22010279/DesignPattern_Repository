using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkTest.Repositories.Interfaces
{
    public interface IRepository<T, Id> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Id id);
        Task<T> GetByIdAsync(Id id);
        Task<IEnumerable<T>> GetAllAsync();
    }


}