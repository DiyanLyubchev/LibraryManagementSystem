using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibrarySystem.Services.Core;
using LibrarySystem.Services.CustomException;
using LibrarySystem.Services.Dto;
using LibrarySystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountWebService service;

        public AccountController(IAccountWebService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult BannedUsers()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BannedUsers(AccountViewModel user)
        {

            try
            {
                var accountDto = new AccountDto
                {
                    Username = user.Username
                };

                var username =await this.service.BanAccountAsync(accountDto);

            }
            catch(UserExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel { Message = $"User with username" +
                $" {user.Username} has been banned" , IsSuccess = true });
        }
        [HttpGet]
        public IActionResult Membership()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Membership(MembershipViewModel vm)
        {
            try
            {
                var membershipDto = new MembershipDto
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Months = vm.Months

                };
                await this.service.CreateMembership(membershipDto);
            }
            catch (UserExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}