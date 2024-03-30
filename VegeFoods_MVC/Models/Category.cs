namespace VegeFoods_MVC.Models
{
    public class Category:Base
    {
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        public List<Product> Product{ get; set; }
    }
}
