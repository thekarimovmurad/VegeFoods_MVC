using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegeFoods_MVC.Models
{
    public class AboutUs: Base
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Subtitle is required")]
        public string Subtitle { get; set; }
        public string Video { get; set; }
        [Display(Name = "Upload Video"), NotMapped]
        public IFormFile VideoFile { get; set; }
        public string Image { get; set; }

        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
