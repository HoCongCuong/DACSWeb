namespace BlogWeb.ViewModels
{
    public class Uservm
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string? imgUser { get; set; }

        public string? phone { get; set; }
    }
}
