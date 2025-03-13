using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<User> Users {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Comment> Comments{get; set;}
        public DbSet<Like> Likes {get; set;}
        public DbSet<Media> MediaFiles{get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>()
           .HasMany(u=>u.Posts)
           .WithOne(p=>p.User).
           HasForeignKey(p=>p.UserId);

           modelBuilder.Entity<Post>()
           .HasMany(p=>p.Comments).
           WithOne(c=>c.Post).
           HasForeignKey(c=>c.PostId);

           modelBuilder.Entity<Post>()
           .HasMany(p=>p.Likes).
           WithOne(l=>l.Post).
           HasForeignKey(l=>l.PostId);

           modelBuilder.Entity<Post>()
           .HasMany(p=>p.MediaFiles).
           WithOne(m=>m.Post).
           HasForeignKey(m=>m.PostId);

          
        }

    }
}