using Goodreads.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Goodreads.Data
{
    public class GoodreadsContext: DbContext
    {
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavourite> UserFavourites { get; set; }


        public GoodreadsContext(DbContextOptions<GoodreadsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary keys 
            
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserFavourite>()
                .HasKey(uf => uf.Id);

            //one to many (Author <-> Book)
            modelBuilder.Entity<Author>().
                HasMany(a => a.Books).
                WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            //many to many (Book <-> Genre)
            modelBuilder.Entity<BookGenre>().
                HasKey(k => new { k.BookId, k.GenreId });

            modelBuilder.Entity<BookGenre>().
                HasOne(bg => bg.Book).
                WithMany(b => b.BookGenre)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>().
                HasOne(bg => bg.Genre).
                WithMany(g => g.BookGenre)
                .HasForeignKey(bg => bg.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
