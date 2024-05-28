using Microsoft.AspNetCore.SignalR;

namespace Client.Pages.SignalRChat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Group("gruop1").SendAsync("ReceiveMessage", user, message);
        }
    }
}
