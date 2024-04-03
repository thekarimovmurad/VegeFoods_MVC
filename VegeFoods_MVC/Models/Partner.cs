using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VegeFoods_MVC.Models
{
    public class Partner:Base
    {
        public string PartnerLogo { get; set; } = string.Empty;
        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
