using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartWorkout.DataAccess.Repositories
{
    public class ExerciseLogRepository : GenericRepository<ExerciseLog>, IDisposable
    {
        public ExerciseLogRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task DeleteAsyncExec(int id1, int id2)
        {
            var t = await _context.Set<ExerciseLog>().FindAsync(id1, id2);

            try
            {
                if (t == null)
                {
                    return;
                }
                _context.Set<ExerciseLog>().Remove(t);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Blud, can't delete what is not there : {ex.Message}", ex);
            }
        }

        public override async Task<ExerciseLog> GetByIdAsyncExec(int id1, int id2)
        {
            return await _context.Set<ExerciseLog>().FindAsync(id1, id2);
        }
    }
}
