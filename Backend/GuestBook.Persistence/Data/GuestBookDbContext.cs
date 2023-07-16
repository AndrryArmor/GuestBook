﻿using GuestBook.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace GuestBook.Persistence.Data
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