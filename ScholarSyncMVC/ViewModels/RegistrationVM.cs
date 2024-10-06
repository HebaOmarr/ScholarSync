using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScholarSyncMVC.ViewModels
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class RegistrationVM
    {


        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage ="Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed.")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        public string? Description { get; set; }
        public string? Nationality { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(25, ErrorMessage = "Max 25 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Please confirm your password.") ]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
