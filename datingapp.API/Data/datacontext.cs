using datingapp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace datingapp.API.Data
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions<datacontext> options) : base (options) {}
        public DbSet<value> Values {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>()
                    .HasKey(k => new { k.LikerId, k.LikeeId});

                    builder.Entity<Like>()
                        .HasOne(u => u.Likee)
                        .WithMany(u => u.Likers)
                        .HasForeignKey(u => u.LikeeId)
                        .OnDelete(DeleteBehavior.Restrict);

                     builder.Entity<Like>()
                        .HasOne(u => u.Liker)
                        .WithMany(u => u.Likees)
                        .HasForeignKey(u => u.LikerId)
                        .OnDelete(DeleteBehavior.Restrict);

                     builder.Entity<Message>()
                        .HasOne(u => u.Sender)
                        .WithMany(m => m.MessagesSent)
                        .OnDelete(DeleteBehavior.Restrict);

                     builder.Entity<Message>()
                        .HasOne(u => u.Recipient)
                        .WithMany(m => m.MessagesReceived)
                        .OnDelete(DeleteBehavior.Restrict);    
                    
                    builder.Entity<Tasks>()
                        .HasOne(u => u.CreatedBy)
                        .WithMany(m => m.TaskCreated)
                        .OnDelete(DeleteBehavior.Restrict);         
        }
    }
}