using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarSyncMVC.Models
{
    public class Requirements : BaseEntity
    {
        public Scholarship Scholarship { get; set; }
        [ForeignKey(nameof(Scholarship))]
        public int ScholarShipId { get; set; }
        public string Requirement { get; set; }


    }


}
