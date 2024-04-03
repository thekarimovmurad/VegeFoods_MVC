using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class Blog: Base
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<BlogTag> BlogTag { get; set; }
    }
}
