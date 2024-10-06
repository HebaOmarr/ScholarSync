namespace ScholarSyncMVC.ViewModels
{
    public class CounryDeptEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoURL { get; set; }
        public string? FilePath { get; set; }

        public IFormFile? PhotoFile { get; set; }
    }
}
