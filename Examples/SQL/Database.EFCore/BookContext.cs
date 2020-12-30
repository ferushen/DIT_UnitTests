using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class BookContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
                
        public BookContext()
        {
        }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=secretpass;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(x => x.id);
                entity.Property(x => x.id).UseIdentityColumn();
            });
           
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity ( 1, "The End of Eternity", "Isaac Asimov", 1955 ));
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity ( 2, "Foundation and Empire", "Isaac Asimov", 1945));
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity ( 3, "The Brothers Karamazov", "Fyodor Dostoyevsky", 1955));
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity ( 4, "The Possessed", "Fyodor Dostoyevsky", 1955));
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity ( 5, "Burning Daylight", "Jack London", 1955));
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}