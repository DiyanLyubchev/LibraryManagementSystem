using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Racks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem
{
    public class LibrarySystemContext : IdentityDbContext<User>
    {

        public LibrarySystemContext()
        {
        }
        public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
          : base(options)
        {
        }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<RackLocation> RackLocations { get; set; }
        public DbSet<RackLetter> RackLetters { get; set; }
        public DbSet<Account> AccountsOldData { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
        public DbSet<BookLending> BookLendings { get; set; }
        public DbSet<BookItem> BookItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString =
          @"Server=.\SQLEXPRESS;Database=Library;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account
            modelBuilder.Entity<Account>()
          .Property(user => user.UserName)
          .HasColumnType("nvarchar(20)")
          .IsRequired();

            modelBuilder.Entity<Account>()
               .Property(user => user.Password)
               .HasColumnType("nvarchar(100)")
               .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(u => u.Type)
                .IsRequired();

            //Book
            modelBuilder.Entity<Book>()
                .Property(book => book.ISBN)
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            modelBuilder.Entity<Book>()
               .Property(book => book.ISBN)
               .HasColumnType("nvarchar(15)")
               .IsRequired();

            modelBuilder.Entity<Book>()
               .Property(book => book.Title)
               .HasColumnType("nvarchar(100)")
               .IsRequired();

            modelBuilder.Entity<Book>()
             .Property(book => book.Subject)
             .HasColumnType("nvarchar(1000)")
             .IsRequired();

            modelBuilder.Entity<Book>()
             .Property(book => book.PublishDate)
             .HasColumnType("nvarchar(50)")
             .IsRequired();

            modelBuilder.Entity<Book>()
             .Property(book => book.Publishers)
             .HasColumnType("nvarchar(30)")
             .IsRequired();

            modelBuilder.Entity<Book>()
             .Property(book => book.Author)
             .HasColumnType("nvarchar(30)")
             .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
