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

        [RegularExpression(@"[a-zA-Z]+$", ErrorMessage = "Name cannot contain spaces or numbers")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^\S+$", ErrorMessage = "Name cannot contain spaces")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid mail format")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [RegularExpression(@"^(?:0[0-9]{9}|0040[0-9]{9}|\+40[0-9]{9})$", ErrorMessage = "Invalid phone nunber format")]
        public string? Phone { get; set; }

        [RegularExpression(@"^([1-3][0-9]{2}?|[3-9][0-9])$", ErrorMessage = "Invalid weight")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public double? Weight { get; set; }

        [RegularExpression(@"^(1[5-9]|[2-8][0-9]|9[0-5])$", ErrorMessage = "Invalid age")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        public int? TrainerId { get; set; } 

        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
    }
}