using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public class WorkoutRepository : GenericRepository<Workout>, IDisposable
    {
        public WorkoutRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _context.Workouts.Include(u => u.User).Include(el => el.Logs).ThenInclude(e => e.Exercise).ToListAsync();
        }
    }
}
