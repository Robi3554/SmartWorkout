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
        private readonly SmartWorkoutContext _context;

        protected bool disposed = false;

        public GenericRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task DeleteAsync(int id)
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T t)
        {
            throw new NotImplementedException();
        }
    }
}
