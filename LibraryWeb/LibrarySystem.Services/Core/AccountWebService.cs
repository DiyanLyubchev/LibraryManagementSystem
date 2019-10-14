using LibrarySystem.DbContext;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Services.CustomException;
using LibrarySystem.Services.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public class AccountWebService : IAccountWebService
    {
        private readonly LibrarySystemContext dbContext;

        public AccountWebService(LibrarySystemContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> BanAccountAsync(AccountDto accountDto)
        {
            var admin = await ReturnAdminAsync();

            if (admin.Any(us => us.UserName == accountDto.Username))
            {
                throw new UserExeption("You cannot ban Admin");
            }

            var user = await this.dbContext.Users
                .FirstOrDefaultAsync(userName => userName.UserName == accountDto.Username);

            if (user == null)
            {              
                throw new UserExeption($"User with the follwing {accountDto.Username} does not exist!");
            }

            await ClearUsersBook(user);

            user.IsBanned = true;

            await this.dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<ICollection<User>> ReturnAdminAsync()
        {
            ICollection<User> admins = new List<User>();

            var adminRole = await this.dbContext.Roles
                .FirstOrDefaultAsync(role => role.Name == "Admin");

            var allAdmins = await this.dbContext.UserRoles
                .Where(roleId => roleId.RoleId == adminRole.Id)
                .ToListAsync();

            foreach (var admin in allAdmins)
            {
                var newAdmin = await this.dbContext.Users
                     .FirstOrDefaultAsync(user => user.Id == admin.UserId);
                if (newAdmin != null)
                {
                    admins.Add(newAdmin);
                }
            }

            return admins;
        }

        public async Task CreateMembership(MembershipDto membershipDto)
        {
            var user = await this.dbContext.Users
                  .FirstOrDefaultAsync(userId => userId.Id == membershipDto.UserId);

            if (user == null)
            {
                throw new UserExeption("Does not exist");
            }

            user.CreatedOn = DateTime.Now;
            user.Expired = DateTime.Now.AddMonths(membershipDto.Months);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string userId)
        {
           var user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task ClearUsersBook(User user)
        {
            var bookLending = await this.dbContext.BookLendings
            .Include(u => u.User)
            .Where(bLending => bLending.UserId == user.Id)
            .ToListAsync();

            foreach (var item in bookLending)
            {
                this.dbContext.BookLendings.Remove(item);
                user.CountLendBooks += 1;
            }

        }
    }
}
