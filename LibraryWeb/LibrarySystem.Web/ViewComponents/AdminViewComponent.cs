using LibrarySystem.Services.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibrarySystem.Web.ViewComponents
{
    public class AdminViewComponent : ViewComponent
    {

        private readonly IAccountWebService accountsService;

        public AdminViewComponent(IAccountWebService accountsService)
        {

            this.accountsService = accountsService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await this.accountsService.GetUserAsync(userID);

            bool exists = currentUser != null;

            return View(exists);
        }
    }
}
