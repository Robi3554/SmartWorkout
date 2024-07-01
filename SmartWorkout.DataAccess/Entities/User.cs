using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression(@"^\S+$", ErrorMessage = "Name cannot contain spaces")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^\S+$", ErrorMessage = "Name cannot contain spaces")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = null!;
        public string? Email { get; set; }

        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must start with 0 and be 10 digits")]
        public string? Phone { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }

        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
    }
}