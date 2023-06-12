using System.ComponentModel.DataAnnotations;

namespace BlogWeb.ViewModels
{
    public class Registervm
    {
        [Required]
        public String? FullName { get; set; }
        [Required]
        [EmailAddress]
        public String? Email { get; set; }  
        public String? UserName { get; set; }
        [Required]
        public String? Password { get; set; }
       
    }
}
