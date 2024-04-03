using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class Size: Base  
    {
        public string Magnitude { get; set; }
        public List<PriceList> PriceList { get; set; }
    }
}
