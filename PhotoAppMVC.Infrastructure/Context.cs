using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoAppMVC.Domain.Model;


namespace PhotoAppMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactInformation> CustomerContactInformations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<BlogDetails> Blogs { get; set; }
        public DbSet<BlogTag> ItemTag { get; set; }
        public DbSet<Photos> Photoses { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PhotoAppMVC.Domain.Model.Type> Types { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasOne(a => a.CustomerContactInformation).WithOne(b => b.Customer)
                .HasForeignKey<CustomerContactInformation>(e => e.CustomerRef);

            builder.Entity<BlogTag>()
                .HasKey(it => new { it.BlogId, it.TagId });

            builder.Entity<BlogTag>()
                .HasOne<BlogDetails>(bl => bl.Blog)
                .WithMany(b => b.BlogTags)
                .HasForeignKey(it => it.BlogId);

            builder.Entity<BlogTag>()
                .HasOne<Tag>(it => it.Tag)
                .WithMany(i => i.BlogTags)
                .HasForeignKey(it => it.TagId);
        }
    }
}
