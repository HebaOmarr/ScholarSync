namespace ScholarSyncMVC.Models
{
    public class Category : BaseEntity 
    {
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public string FilePath { get; set; }
        public string? Description { get; set; }

    }

}
