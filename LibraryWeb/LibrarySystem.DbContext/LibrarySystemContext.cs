using LibrarySystem.Accounts;
using LibrarySystem.Books;
using LibrarySystem.Models;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Notifications;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DbContext
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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
        public DbSet<BookLending> BookLendings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString =
          @"Server=.\SQLEXPRESS;Database=LibraryDatabase;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
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

            modelBuilder.Entity<Book>().HasData(BookSeed());
            modelBuilder.UserRole();
        }

        private Book[] BookSeed()
        {
            var books = new Book[]
            {
                new Book
                {
                    Id = 1,
                    ISBN = "9781593275846",
                    Title = "Assassin's creed",
                    Author = "Oliver Bowden",
                    PublishDate = "2011-11-10",
                    Publishers = "Era",
                    Pages = 300,
                    Subject = "Romance",
                    Picture = "https://prodimage.images-bn.com/pimages/9780441019298_p0_v2_s600x595.jpg"
                },

                new Book
                {
                    Id = 2,
                    ISBN = "9784445814481",
                    Title = "Angels & Demons",
                    Author = "Dan Brown",
                    PublishDate = "2000-11-10",
                    Publishers = "Soft Press",
                    Pages = 616,
                    Subject = "Thriller",
                    Picture = "https://images.gr-assets.com/books/1348224767l/6496832.jpg"
                },

                new Book
                {
                    Id = 3,
                    ISBN = "9785213275846",
                    Title = "The chalk man",
                    Author = "C. J. Tudor   ",
                    PublishDate = "2018-01-09",
                    Publishers = "Colibri",
                    Pages = 309,
                    Subject = "Thriller",
                    Picture = "https://www.booktopia.com.au/http_coversbooktopiacomau/600/9781405930956/7333/the-chalk-man.jpg"
                },

                new Book
                {
                    Id = 4,
                    ISBN = "9782593321154",
                    Title = "Child 44",
                    Author = "Tom Rob Smith",
                    PublishDate = "2008-11-10",
                    Publishers = "Lachezar Minchev",
                    Pages = 459,
                    Subject = "Thriller",
                    Picture = "https://images-na.ssl-images-amazon.com/images/I/71AG8v3O7vL.jpg"
                },

                new Book
                {
                    Id = 5,
                    ISBN = "978993111146",
                    Title = "It",
                    Author = "Stephen King",
                    PublishDate = "1986-09-15",
                    Publishers = "Era",
                    Pages = 1138,
                    Subject = "Horror novel",
                    Picture = "https://prodimage.images-bn.com/pimages/9781982127794_p0_v3_s550x406.jpg"
                },

                new Book
                {
                    Id = 6,
                    ISBN = "9786190204725",
                    Title = "The good daughter",
                    Author = "Karin Slaughter",
                    PublishDate = "2017-06-18",
                    Publishers = "Colibri",
                    Pages = 650,
                    Subject = "Thriller",
                    Picture = "https://images-na.ssl-images-amazon.com/images/I/510te6onEgL.jpg"
                },

                new Book
                {
                    Id = 7,
                    ISBN = "9789545853418",
                    Title = "Kane and Abel",
                    Author = "Jeffrey Archer",
                    PublishDate = "2010-02-20",
                    Publishers = "Bard",
                    Pages = 579,
                    Subject = "Thriller",
                    Picture = "https://imgv2-2-f.scribdassets.com/img/word_document/182528889/298x396/1df0eae438/1567186294?v=1"
                },

                new Book
                {
                    Id = 8,
                    ISBN = "9789545855283",
                    Title = "The prodigal daughter",
                    Author = "Jeffrey Archer",
                    PublishDate = "2008-05-08",
                    Publishers = "Bard",
                    Pages = 479,
                    Subject = "Novel",
                    Picture = "https://panmacmillanapi.blob.core.windows.net/pmapi/e12a8195-4610-4b2d-fa9f-08d58e45775c/editions/56e116c5-c116-43e5-c211-08d5dd189c4a/original_400_600.jpg"
                },

                new Book
                {
                    Id = 9,
                    ISBN = "9788387834111",
                    Title = "The notebook",
                    Author = "Nicholas Sparks",
                    PublishDate = "1996-10-01",
                    Publishers = "Warner Books",
                    Pages = 214,
                    Subject = "Novel",
                    Picture = "https://nicholassparks.com/wp-content/uploads/1996/07/201612-notebook.jpg"
                },

                new Book
                {
                    Id = 10,
                    ISBN = "9780785941743",
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    PublishDate = "2000-11-24",
                    Publishers = "Bantam Books",
                    Pages = 689,
                    Subject = "Mystery thriller",
                    Picture = "https://kbimages1-a.akamaihd.net/185e7463-9792-4728-8403-d91a6352d549/1200/1200/False/the-da-vinci-code-1.jpg"
                },
            };

            return books;
        }
    }
}

