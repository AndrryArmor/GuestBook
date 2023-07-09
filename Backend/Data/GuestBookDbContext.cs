using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace GuestBook.Data
{
    public class GuestBookDbContext : DbContext
    {
        public GuestBookDbContext(DbContextOptions<GuestBookDbContext> options) : base(options)
        {
        }

        public DbSet<UserComment> UserComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserComment>()
                .Property(uc => uc.PublicationDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
