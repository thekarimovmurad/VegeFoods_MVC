namespace VegeFoods_MVC.Models
{
    public class Testomonial:Base
    {
        public required string ProfileImage { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
