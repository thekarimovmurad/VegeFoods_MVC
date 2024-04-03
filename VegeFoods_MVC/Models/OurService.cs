using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VegeFoods_MVC.Models
{
    public class OurService: Base
    {
        [Required(ErrorMessage = "SVG Image is required")]
        public string SVGImage {get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Subtitle is required")]
        public string Subtitle { get; set; }
    }
}
