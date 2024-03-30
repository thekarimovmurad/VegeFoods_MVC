using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegeFoods_MVC.Models
{
    public class Slider:Base
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Subtitle is required")]
        public string Subtitle { get; set; }
        public string BackgroundImage { get; set; }=string.Empty;
        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
