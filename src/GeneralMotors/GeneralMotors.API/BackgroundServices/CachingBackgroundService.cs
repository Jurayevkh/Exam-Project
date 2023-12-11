namespace GeneralMotors.API.BackgroundServices;

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
            var carClient = await _mediator.Send(new GetAllCarClientQuery());
            var cars = await _mediator.Send(new GetAllCarQuery());
            var carTypes = await _mediator.Send(new GetAllCarTypesQuery());
            var clients = await _mediator.Send(new GetAllClientQuery());
            var dillers = await _mediator.Send(new GetAllDillerQuery());


            var carClientCache = JsonSerializer.Serialize(carClient);
            var carCache = JsonSerializer.Serialize(cars);
            var carTypesCache = JsonSerializer.Serialize(carTypes);
            var clientsCache = JsonSerializer.Serialize(clients);
            var dillersCache = JsonSerializer.Serialize(dillers);

            await _distributedCache.SetStringAsync("GetAllCarClient", carClientCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            await _distributedCache.SetStringAsync("GetAllCar", carCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            await _distributedCache.SetStringAsync("GetAllCarType", carTypesCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            await _distributedCache.SetStringAsync("GetAllClient", clientsCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            await _distributedCache.SetStringAsync("GetAllDiller", dillersCache, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        };
    }
}

