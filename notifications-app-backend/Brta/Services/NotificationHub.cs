using Microsoft.AspNetCore.SignalR;

namespace NewsApi.Services
{
    public class NotificationHub : Hub
    {
        //Broadcast a message to every connected user.
        public async Task BroadcastMessage(object[] messages)
        {
            await Clients.All.SendAsync("message_received", messages);
        }
    }
}
