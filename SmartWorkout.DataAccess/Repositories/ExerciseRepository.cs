﻿using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IDisposable
    {
        public ExerciseRepository(SmartWorkoutContext context) : base(context)
        {
        }
    }
}
