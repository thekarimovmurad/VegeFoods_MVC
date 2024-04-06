using Microsoft.EntityFrameworkCore;
using System;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Testomonial> Testomonials { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<PartnerCount> PartnerCounts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContactUs> ContacUs { get; set; }
    }
}