namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public CarTypeController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCarType()
        {
            var fromCache = await _distributedCache.GetStringAsync($"GetAllCarType");
            if (fromCache is null)
            {
                var cartypes = await _mediator.Send(new GetAllCarTypesQuery());

                fromCache = JsonSerializer.Serialize(cartypes);
                await _distributedCache.SetStringAsync($"GetAllCarType", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<CarType>>(fromCache);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCarType(int id)
        {

            var fromCache = await _distributedCache.GetStringAsync($"CarType{id}");

            if (fromCache is null)
            {
                var carType = await _mediator.Send(new GetByIdCarTypeQuery() { Id = id });

                fromCache = JsonSerializer.Serialize(carType);
                await _distributedCache.SetStringAsync($"CarType{carType.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<CarType>(fromCache);

            return Ok(result);

        }

    }
}

