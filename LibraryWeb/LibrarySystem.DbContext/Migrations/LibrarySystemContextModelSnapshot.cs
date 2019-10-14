﻿// <auto-generated />
using System;
using LibrarySystem.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibrarySystem.DbContext.Migrations
{
    [DbContext(typeof(LibrarySystemContext))]
    partial class LibrarySystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibrarySystem.Books.BookLending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("ReturnDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookLendings");
                });

            modelBuilder.Entity("LibrarySystem.Books.BookReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("BookId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("NotificationId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("NotificationId")
                        .IsUnique()
                        .HasFilter("[NotificationId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("BookReservations");
                });

            modelBuilder.Entity("LibrarySystem.Models.Accounts.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CountLendBooks");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime?>("Expired");

                    b.Property<bool>("IsBanned");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "928584d2-efee-4f90-a7a2-3b917ef4dc34",
                            CountLendBooks = 5,
                            Email = "admin1@admin.com",
                            EmailConfirmed = false,
                            IsBanned = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN1@ADMIN.COM",
                            NormalizedUserName = "DIYAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEFI2Oz2odIAXG1gSm2d13ao/S8oSZGJxHBpE7aa2NgZ/RW42LUpKXwD5QQ0me/5dKQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                            TwoFactorEnabled = false,
                            UserName = "Diyan"
                        },
                        new
                        {
                            Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "830b1e20-fd26-4ae8-b6a6-b0d68c25871b",
                            CountLendBooks = 5,
                            Email = "admin2@admin.com",
                            EmailConfirmed = false,
                            IsBanned = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN2@ADMIN.COM",
                            NormalizedUserName = "BOBI",
                            PasswordHash = "AQAAAAEAACcQAAAAEAUDfZr89Bn7m01zQplk0cj9LSmvCauQC+ShjneB++MhbEBErN6bhAerBUeGX5ZpRw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU",
                            TwoFactorEnabled = false,
                            UserName = "Bobi"
                        });
                });

            modelBuilder.Entity("LibrarySystem.Models.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Pages");

                    b.Property<string>("Picture");

                    b.Property<string>("PublishDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Publishers")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Oliver Bowden",
                            ISBN = "9781593275846",
                            Pages = 300,
                            Picture = "https://prodimage.images-bn.com/pimages/9780441019298_p0_v2_s600x595.jpg",
                            PublishDate = "2011-11-10",
                            Publishers = "Era",
                            Subject = "Romance",
                            Title = "Assassin's creed"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Dan Brown",
                            ISBN = "9784445814481",
                            Pages = 616,
                            Picture = "https://images.gr-assets.com/books/1348224767l/6496832.jpg",
                            PublishDate = "2000-11-10",
                            Publishers = "Soft Press",
                            Subject = "Thriller",
                            Title = "Angels & Demons"
                        },
                        new
                        {
                            Id = 3,
                            Author = "C. J. Tudor   ",
                            ISBN = "9785213275846",
                            Pages = 309,
                            Picture = "https://www.booktopia.com.au/http_coversbooktopiacomau/600/9781405930956/7333/the-chalk-man.jpg",
                            PublishDate = "2018-01-09",
                            Publishers = "Colibri",
                            Subject = "Thriller",
                            Title = "The chalk man"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Tom Rob Smith",
                            ISBN = "9782593321154",
                            Pages = 459,
                            Picture = "https://images-na.ssl-images-amazon.com/images/I/71AG8v3O7vL.jpg",
                            PublishDate = "2008-11-10",
                            Publishers = "Lachezar Minchev",
                            Subject = "Thriller",
                            Title = "Child 44"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Stephen King",
                            ISBN = "978993111146",
                            Pages = 1138,
                            Picture = "https://prodimage.images-bn.com/pimages/9781982127794_p0_v3_s550x406.jpg",
                            PublishDate = "1986-09-15",
                            Publishers = "Era",
                            Subject = "Horror novel",
                            Title = "It"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Karin Slaughter",
                            ISBN = "9786190204725",
                            Pages = 650,
                            Picture = "https://images-na.ssl-images-amazon.com/images/I/510te6onEgL.jpg",
                            PublishDate = "2017-06-18",
                            Publishers = "Colibri",
                            Subject = "Thriller",
                            Title = "The good daughter"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Jeffrey Archer",
                            ISBN = "9789545853418",
                            Pages = 579,
                            Picture = "https://imgv2-2-f.scribdassets.com/img/word_document/182528889/298x396/1df0eae438/1567186294?v=1",
                            PublishDate = "2010-02-20",
                            Publishers = "Bard",
                            Subject = "Thriller",
                            Title = "Kane and Abel"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Jeffrey Archer",
                            ISBN = "9789545855283",
                            Pages = 479,
                            Picture = "https://panmacmillanapi.blob.core.windows.net/pmapi/e12a8195-4610-4b2d-fa9f-08d58e45775c/editions/56e116c5-c116-43e5-c211-08d5dd189c4a/original_400_600.jpg",
                            PublishDate = "2008-05-08",
                            Publishers = "Bard",
                            Subject = "Novel",
                            Title = "The prodigal daughter"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Nicholas Sparks",
                            ISBN = "9788387834111",
                            Pages = 214,
                            Picture = "https://nicholassparks.com/wp-content/uploads/1996/07/201612-notebook.jpg",
                            PublishDate = "1996-10-01",
                            Publishers = "Warner Books",
                            Subject = "Novel",
                            Title = "The notebook"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Dan Brown",
                            ISBN = "9780785941743",
                            Pages = 689,
                            Picture = "https://kbimages1-a.akamaihd.net/185e7463-9792-4728-8403-d91a6352d549/1200/1200/False/the-da-vinci-code-1.jpg",
                            PublishDate = "2000-11-24",
                            Publishers = "Bantam Books",
                            Subject = "Mystery thriller",
                            Title = "The Da Vinci Code"
                        });
                });

            modelBuilder.Entity("LibrarySystem.Models.Books.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("Comment")
                        .HasMaxLength(400);

                    b.Property<int?>("Rating")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("LibrarySystem.Models.Notifications.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Seen");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "69e7930c-3df5-4261-99cf-0352eb018a91",
                            RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8"
                        },
                        new
                        {
                            UserId = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                            RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LibrarySystem.Accounts.RoleUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("RoleUser");

                    b.HasData(
                        new
                        {
                            Id = "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                            ConcurrencyStamp = "d8458760-9cca-4dff-8e37-d0aaa33dbdf6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("LibrarySystem.Books.BookLending", b =>
                {
                    b.HasOne("LibrarySystem.Models.Books.Book", "Book")
                        .WithMany("BookLendings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Models.Accounts.User", "User")
                        .WithMany("BookLendings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LibrarySystem.Books.BookReservation", b =>
                {
                    b.HasOne("LibrarySystem.Models.Books.Book", "Book")
                        .WithMany("BookReservations")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Models.Notifications.Notification", "Notification")
                        .WithOne("BookReservation")
                        .HasForeignKey("LibrarySystem.Books.BookReservation", "NotificationId");

                    b.HasOne("LibrarySystem.Models.Accounts.User", "User")
                        .WithMany("BookReservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LibrarySystem.Models.Books.Review", b =>
                {
                    b.HasOne("LibrarySystem.Models.Books.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Models.Accounts.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LibrarySystem.Models.Accounts.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibrarySystem.Models.Accounts.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Models.Accounts.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LibrarySystem.Models.Accounts.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
