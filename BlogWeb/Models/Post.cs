﻿namespace BlogWeb.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        //relation
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string? ThumbnailUrl { get; set; }
        public Category? categorys { get; set; }
        public bool? published { get; set; }
        public int? CategoryId { get; set; }
        public comment? comment { get; set; }
    }
}
