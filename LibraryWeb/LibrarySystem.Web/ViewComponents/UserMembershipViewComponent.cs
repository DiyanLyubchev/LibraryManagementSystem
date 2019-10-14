using LibrarySystem.Services.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibrarySystem.Web.ViewComponents
{
    public class UserMembershipViewComponent : ViewComponent
    {
        private readonly IAccountWebService accountsService;

        public UserMembershipViewComponent(IAccountWebService accountsService)
        {

            this.accountsService = accountsService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await this.accountsService.GetUserAsync(userID);

            bool isExpired = currentUser.Expired == null || currentUser.Expired < DateTime.Now;

            return View(isExpired);
        }
    }
}
