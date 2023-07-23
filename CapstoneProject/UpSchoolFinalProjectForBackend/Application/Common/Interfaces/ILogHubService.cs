namespace Application.Common.Interfaces;

public interface ILogHubService
{
    Task RemovedAsync(Guid id, CancellationToken cancellationToken);
}