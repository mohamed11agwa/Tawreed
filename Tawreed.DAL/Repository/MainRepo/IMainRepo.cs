using System;
using System.Collections.Generic;
using System.Text;

namespace Tawreed.DAL.Repository.MainRepo
{
    public interface IMainRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
