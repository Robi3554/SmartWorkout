using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class ExerciseLog
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int? Sets { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int? Reps { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? Weight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? Duration { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? Distance { get; set; }
        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}