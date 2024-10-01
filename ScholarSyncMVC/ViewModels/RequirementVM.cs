using ScholarSyncMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarSyncMVC.ViewModels
{
    public class RequirementVM
    {
        public int Id { get; set; }
        public Scholarship? Scholarship { get; set; }
        public int ScholarShipId { get; set; }
        public string Requirement { get; set; }
        public IEnumerable<Scholarship> scholarships { get; set; }= new List<Scholarship>();
    }
}
