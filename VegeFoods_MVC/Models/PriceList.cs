using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class PriceList :Base
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}