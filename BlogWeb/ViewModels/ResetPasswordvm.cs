using System.ComponentModel.DataAnnotations;

namespace BlogWeb.ViewModels
{
    public class ResetPasswordvm
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Compare(nameof(NewPassword))]
        [Required]
        public string? ConfirmPasswor { get; set; }
    }
}
