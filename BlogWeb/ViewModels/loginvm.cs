using System.ComponentModel.DataAnnotations;

namespace BlogWeb.ViewModels
{
    public class loginvm
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
