using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IDisposable
    {
        public UserRepository(SmartWorkoutContext context) : base(context)
        {
        }
    }
}
