using System.Drawing;
using System.Net;
using VegeFoods_MVC.Models;
using Size = VegeFoods_MVC.Models.Size;
namespace VegeFoods_MVC.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> sliders { get; set; }
        public List<OurService> ourServices { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
        public List<Partner> partners { get; set; }
        public List<Testomonial> testomonials { get; set; }
    }
}
