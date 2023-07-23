using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Services;

public class LogHubManager:ILogHubService
{
    private readonly IHubContext<LogHub> _hubContext;

    public LogHubManager(IHubContext<LogHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task RemovedAsync(Guid id, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All.SendAsync("Removed",id,cancellationToken);
    }
}