﻿using BlogWeb.Models;
using X.PagedList;

namespace BlogWeb.ViewModels
{
    public class Homevm
    {
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? ThumbnailUrl { get; set; }
        public IPagedList<Post>? Posts { get; set; }
    }
}
