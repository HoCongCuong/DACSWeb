using BlogWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.ViewModels
{
    public class createpostvm
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public int? CategoryNameId { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }
        public List<Category>? Categories { get; internal set; }
    }
}
