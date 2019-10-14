using LibrarySystem.Accounts;
using LibrarySystem.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DbContext
{
    public static class ApplicationUserSeed
    {
        public static void UserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RoleUser>()
                .HasData(new RoleUser
                {
                    Id = "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            var hasher = new PasswordHasher<User>();

            var adminDiyan = new User
            {
                Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                UserName = "Diyan",
                NormalizedUserName = "DIYAN",
                Email = "admin1@admin.com",
                NormalizedEmail = "ADMIN1@ADMIN.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };
            var adminBobi = new User
            {
                Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                UserName = "Bobi",
                NormalizedUserName = "BOBI",
                Email = "admin2@admin.com",
                NormalizedEmail = "ADMIN2@ADMIN.COM",
                SecurityStamp = "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU",
                LockoutEnabled = true
            };

            adminDiyan.PasswordHash = hasher.HashPassword(adminDiyan, "123456");
            adminBobi.PasswordHash = hasher.HashPassword(adminBobi, "234567");
            modelBuilder.Entity<User>().HasData(adminDiyan, adminBobi);

            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string> { UserId = adminDiyan.Id, RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8" }, new IdentityUserRole<string> { UserId = adminBobi.Id, RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8" });
        }
    }
}
