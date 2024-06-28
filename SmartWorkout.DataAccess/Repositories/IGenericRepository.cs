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
        Task<T> GetUserByIdAsync(int id);
        Task<T> AddUserAsync(T t);
        Task<T> UpdateUserAsync(T t);
        Task DeleteUserAsync(int id);
    }
}
