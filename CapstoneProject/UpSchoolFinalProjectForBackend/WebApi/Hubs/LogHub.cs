using Domain.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class LogHub:Hub
{
    public async Task SendLogNotificationAsync(LogDto log)
    {
        await Clients.AllExcept(Context.ConnectionId).SendAsync("NewLogAdded", log);
    }
}