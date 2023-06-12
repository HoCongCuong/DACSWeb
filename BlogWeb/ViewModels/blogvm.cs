namespace BlogWeb.ViewModels
{
    public class blogvm
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int? CategoryNameId { get; set; }
    }
}
