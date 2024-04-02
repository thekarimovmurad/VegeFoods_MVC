using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VegeFoods_MVC.Models
{
    public class Partner:Base
    {
        public string PartnerLogo { get; set; } = string.Empty;
        [Display(Name = "Upload Image"), NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
