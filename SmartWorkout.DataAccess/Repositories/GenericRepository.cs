using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        public SmartWorkoutContext _context;

        public GenericRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public async Task<T> AddUserAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task DeleteUserAsync(int id)
        {
            var t = await _context.Set<T>().FindAsync(id);

            try
            {
                if (t == null)
                {
                    return;
                }
                _context.Set<T>().Remove(t);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Blud, can't delete what is not there : {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateUserAsync(T t)
        {
            throw new NotImplementedException();
        }
    }
}
