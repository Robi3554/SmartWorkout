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

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid mail format")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?:0[0-9]{9}|0040[0-9]{9}|\+40[0-9]{9})$", ErrorMessage = "Invalid phone nunber format")]
        public string? Phone { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }

        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
    }
}