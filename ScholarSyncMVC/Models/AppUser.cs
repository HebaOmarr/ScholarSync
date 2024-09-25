using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarSyncMVC.Models
{
    public class AppUser:IdentityUser
    {
        public Department Department { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
    }
}
