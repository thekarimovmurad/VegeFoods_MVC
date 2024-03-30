using System.Drawing;
using VegeFoods_MVC.Models;
using Size = VegeFoods_MVC.Models.Size;

namespace VegeFoods_MVC.ViewModels
{
    public class AboutViewModel
    {
        public AboutUs aboutUs { get; set; }
        public List<OurService> ourServices { get; set; }
        public List<Testomonial> testomonials { get; set; }
        public PartnerCount partnerCounts { get; set; }
    }
}
