using System.ComponentModel.DataAnnotations;

namespace Drinks_Go.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}