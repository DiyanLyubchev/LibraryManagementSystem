using LibrarySystem.Services.Core;
using LibrarySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibrarySystem.Web.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        public readonly INotificationService notification;

        public NotificationViewComponent(INotificationService notification)
        {

            this.notification = notification;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string lastNotification = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                await this.notification.SyncNotificationsAsync(User.Identity.Name);
                lastNotification = await this.notification.GetLastNotificationAsync(User.Identity.Name);
            }

            return View(new BaseViewModel { LastNotification = lastNotification });
        }
    }
}
