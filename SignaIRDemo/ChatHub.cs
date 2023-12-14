
using Furion.InstantMessaging;
using Microsoft.AspNetCore.SignalR;

namespace SignaIRDemo
{
    [MapHub("/ChatRoomHub")]
    public class ChatHub : Hub
    {
        public override async Task<Task> OnConnectedAsync()
        {
            //中间逻辑
            return Clients.All.SendAsync("连接成功");
        }
    }
}
