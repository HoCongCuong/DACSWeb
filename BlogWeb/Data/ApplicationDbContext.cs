﻿using BlogWeb.Models;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace BlogWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Models.Page>? Pages { get; set; }
        public DbSet<Category>? Categorys { get; set; }
        public DbSet<comment>? comments { get; set; }
        public DbSet<Setting>? Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.CategoryId, "fk_category");
            });

            builder.Entity<comment>(entity =>
            {
                entity.ToTable("comment");
            });
            

            base.OnModelCreating(builder);
        }
    }
}
