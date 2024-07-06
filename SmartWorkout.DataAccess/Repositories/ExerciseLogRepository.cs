using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public class ExerciseLogRepository : GenericRepository<ExerciseLog>, IDisposable
    {
        public ExerciseLogRepository(SmartWorkoutContext context) : base(context)
        {
        }
    }
}
