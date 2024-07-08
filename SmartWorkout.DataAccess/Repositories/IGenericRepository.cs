using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public interface IGenericRepository<T>: IDisposable
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(int id);
        Task DeleteAsyncExec(int id1, int id2);
        Task<T> GetByIdAsyncExec(int id1, int id2);
    }
}
