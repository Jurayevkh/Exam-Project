namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public CarClientController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }



        [HttpGet]
        public async ValueTask<IActionResult> GetAllCarClient()
        {
            var fromCache = await _distributedCache.GetStringAsync($"GetAllCarClient");

            if (fromCache is null)
            {
                var carClient = await _mediator.Send(new GetAllCarClientQuery());

                fromCache = JsonSerializer.Serialize(carClient);
                await _distributedCache.SetStringAsync($"GetAllCarClient", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<CarClient>>(fromCache);

            return Ok(result);

        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCarClient(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"CarClient{id}");

            if (fromCache is null)
            {
                var carClient = await _mediator.Send(new GetByIdCarClientQuery() { Id = id });

                fromCache = JsonSerializer.Serialize(carClient);
                await _distributedCache.SetStringAsync($"CarClient{carClient.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<CarClient>(fromCache);

            return Ok(result);
           
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCarClient(CreateCarClientDto createCarClientDto)
        {
            CreateCarClientCommand client = new CreateCarClientCommand()
            {
                CarId=createCarClientDto.CarId,
                UserName=createCarClientDto.UserName
            };
            
            var result=await _mediator.Send(client);

            return Ok(result);
        }



        //[HttpGet]
        //public async ValueTask<IActionResult> GetByIdClients(int id)
        //{

        //}









    }
}

