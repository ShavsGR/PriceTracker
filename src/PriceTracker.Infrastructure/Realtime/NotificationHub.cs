using Microsoft.AspNetCore.SignalR;

namespace PriceTracker.Infrastructure.Realtime
{
    public class NotificationHub : Hub
    {
        public async Task SuscribeToUser(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
    }
}
