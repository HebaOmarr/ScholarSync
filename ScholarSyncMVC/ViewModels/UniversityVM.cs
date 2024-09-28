using System.ComponentModel.DataAnnotations;

namespace ScholarSyncMVC.ViewModels
{
	public class UniversityVM
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		[MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Contact Info is required.")]
		public string ContactInfo { get; set; }
	}
}
