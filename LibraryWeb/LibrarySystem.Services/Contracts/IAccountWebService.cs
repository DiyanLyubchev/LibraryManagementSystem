using LibrarySystem.Models.Accounts;
using LibrarySystem.Services.Dto;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public interface IAccountWebService
    {
        Task<User> BanAccountAsync(AccountDto accountDto);
        Task CreateMembership(MembershipDto membershipDto);

        Task<User> GetUserAsync(string userId);
    }
}