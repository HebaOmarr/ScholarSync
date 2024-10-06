using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarSyncMVC.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username or email are required.")]
        [DisplayName("Username or Email")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(25, ErrorMessage = "Max 25 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
