using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public interface INotificationService
    {
        Task<string> GetLastNotificationAsync(string username);
        Task SyncNotificationsAsync(string username);
    }
}