using System.ComponentModel.DataAnnotations;

namespace Filmative.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Confirmation does not Match the Password")]
        public string ConfirmPassword { get; set; }
    }
}
