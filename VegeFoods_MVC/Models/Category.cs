using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class Category:Base
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
        public List<Product> Product{ get; set; }
        public List<Blog> Blog{ get; set; }
    }
}
