using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.ViewModels
{
    public class BlogViewModel
    {
        public List<Category> categories { get; set; }
        public List<Blog> blogs { get; set; }
        public List<Tag> tags { get; set; }

    }
}
