using BlogWeb.Models;

namespace BlogWeb.ViewModels
{
    public class BlogPostvm
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? ShortDescription { get; set; }
        public string? imgUser { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set;}

        public Post? Posts { get; set; }
        public List<comment>? Comments { get; set; }

    }
}
