namespace QRCodes.API.BackgroundServices;

public class CachingBackgroundService : BackgroundService
{
    private readonly IDistributedCache _distributedCache;
    private readonly IMediator _mediator;

    public CachingBackgroundService(IDistributedCache distributedCache, IMediator mediator)
    {
        _distributedCache = distributedCache;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(2));

        while (await periodicTimer.WaitForNextTickAsync(stoppingToken))
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            var usersCache = JsonSerializer.Serialize(users);
            await _distributedCache.SetStringAsync("GetAllUsers", usersCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        }
    }
}

