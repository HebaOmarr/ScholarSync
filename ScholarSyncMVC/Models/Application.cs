using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarSyncMVC.Models
{
    public class Application:BaseEntity
    {
        public Scholarship? Scholarship { get; set; }
        public int? ScholarshipId { get; set; }
        public AppUser User { get; set; }

        //the default in identity for id datatype "string"
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
