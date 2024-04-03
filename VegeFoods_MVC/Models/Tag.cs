using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class Tag:Base
    {
        public string Name { get; set; }
        public List<BlogTag> BlogTag { get; set; }
    }
}
