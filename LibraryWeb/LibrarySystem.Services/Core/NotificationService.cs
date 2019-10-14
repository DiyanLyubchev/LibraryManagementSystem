using LibrarySystem.Books;
using LibrarySystem.DbContext;
using LibrarySystem.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public  class NotificationService : INotificationService
    {
        private LibrarySystemContext context;

        public NotificationService(LibrarySystemContext context)
        {
            this.context = context;
        }

        public async Task SyncNotificationsAsync(string username)
        {
            var bookReservations =await this.context.BookReservations
                .Include(item => item.Book)
                .Include(item => item.User)
                .Where(item => item.Active
                    && item.User.UserName == username
                    && item.NotificationId == null)
                .ToListAsync();

            var notificationReservations = new List<BookReservation>();

            foreach (var reservation in bookReservations)
            {
                var isTaken =await this.context.BookLendings
                    .Include(item => item.Book)
                    .Include(item => item.User)
                    .AnyAsync(item => item.BookId == reservation.BookId
                        && !item.ReturnDate.HasValue
                        && item.Date.AddDays(10) > DateTime.Now);

                if (!isTaken)
                {
                   notificationReservations.Add(reservation);
                }
            }

            if (notificationReservations.Any())
            {
               await this.context.Notifications.AddRangeAsync(notificationReservations
                    .Select(item => new Notification { BookReservation = item }));
               await this.context.SaveChangesAsync();
            }

        }

        public async Task<string> GetLastNotificationAsync(string username)
        {
            var lastNotification =await this.context.Notifications
                .Include(notification => notification.BookReservation)
                .Include(notification => notification.BookReservation.Book)
                .Include(notification => notification.BookReservation.User)
                .Where(notification => notification.BookReservation.User.UserName == username
                    && !notification.Seen
                    && notification.BookReservation != null
                    && notification.BookReservation.Active)
                .OrderByDescending(notification => notification.BookReservation.Date)
                .FirstOrDefaultAsync();

            return lastNotification != null ? $"{lastNotification.BookReservation.Book.Title} is available!" : string.Empty;
        }
    }
}
