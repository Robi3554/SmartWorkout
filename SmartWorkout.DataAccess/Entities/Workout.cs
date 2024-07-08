﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int? Duration { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; } = null!;
        public ICollection<ExerciseLog> Logs { get; set; } = new HashSet<ExerciseLog>();
    }
}