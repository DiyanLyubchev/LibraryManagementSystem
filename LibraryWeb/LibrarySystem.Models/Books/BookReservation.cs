using LibrarySystem.Models.Notifications;

namespace LibrarySystem.Books
{
    public class BookReservation : BookRegistry
    {
        public bool Active { get; set; } = true;
        public int? NotificationId { get; set; }
        public Notification Notification { get; set; }
    }
}