using LibrarySystem.Accounts;
using LibrarySystem.DbContext;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Services.Core;
using LibrarySystem.Services.CustomException;
using LibrarySystem.Services.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.UnitTest.UserTest
{
    [TestClass]
    public class User_Should
    {

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowExeptionWhenUserIsAdminBanUser_Test()
        {
            var username = "TestName";

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenUserIsAdminBanUser_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var identityRole = new RoleUser
                {
                    Id = "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                await actContext.Roles.AddAsync(identityRole);
                var adminTest = await actContext.Users.AddAsync(new User { UserName = username });

                var accountDto = new AccountDto
                {
                    Username = username
                };

                var user = new IdentityUserRole<string> { UserId = adminTest.Entity.Id, RoleId = "77aedcd5-c539-40cd-b88e-e30ff108e6b8" };

                await actContext.SaveChangesAsync();


                var sut = new AccountWebService(actContext);
                var userBan = await sut.BanAccountAsync(accountDto);

               // Assert.IsTrue(userBan.IsBanned);
            }

       

            using (var assertContext = new LibrarySystemContext(options))
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task IncorrectBanUser_Test()
        {
            var username = "TestName";


            var options = TestUtilities.GetOptions(nameof(IncorrectBanUser_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Users.AddAsync(new User { UserName = "Username" });
                await actContext.SaveChangesAsync();
            }

            var accountDto = new AccountDto
            {
                Username = username
            };

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new AccountWebService(assertContext);
                var userBan = await sut.BanAccountAsync(accountDto);
            }
        }
    }
}
