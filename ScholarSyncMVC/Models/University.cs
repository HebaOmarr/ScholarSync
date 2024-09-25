using System.ComponentModel.DataAnnotations;

namespace ScholarSyncMVC.Models
{
    public class University: BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }

}
