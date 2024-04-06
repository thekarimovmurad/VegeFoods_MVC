using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VegeFoods_MVC.Models
{
    public class ContactUs:Base
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Display(Name = "Message")]
        public string Message { get; set; }
        public DateTime? Time { get; set; }
        public bool Read { get; set; }= false;
    }
}
