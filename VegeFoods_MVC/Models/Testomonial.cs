using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VegeFoods_MVC.Models
{
    public class Testomonial:Base
    {
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
