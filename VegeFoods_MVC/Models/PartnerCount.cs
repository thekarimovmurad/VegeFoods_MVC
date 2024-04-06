using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VegeFoods_MVC.Models
{
    public class PartnerCount:Base
    {
        [Required(ErrorMessage = "Happy user count is required")]
		public int HappyUser { get; set; }
		[Required(ErrorMessage = "Awards count is required")]
        public int Awards {get; set; }
		[Required(ErrorMessage = "Branch count is required")]
        public int Branch { get; set; }
		[Required(ErrorMessage = "Partner count is required")]
        public int Partner { get; set; }
		public string BackgroundImage { get; set; } = string.Empty;
		[Display(Name = "Upload Image"), NotMapped]
		public IFormFile ImageFile { get; set; }
	}
}
