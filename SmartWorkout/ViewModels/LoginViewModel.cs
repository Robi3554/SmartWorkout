using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Please Input an Username")]
        public string? Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Input a Password")]
        public string? Password { get; set; }
    }
}
