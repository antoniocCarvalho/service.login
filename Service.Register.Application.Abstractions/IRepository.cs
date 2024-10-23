using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Register.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetUserByIdAsync(string Id);
        Task<List<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
