using GeneralMotors.Domain.Entities.Clients;
using GeneralMotors.Domain.Entities.Dillers;
using Microsoft.Extensions.Caching.Distributed;

namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DillerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public DillerController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdDiller(int id)
        {

            var fromCache = await _distributedCache.GetStringAsync($"Diller{id}");

            if (fromCache is null)
            {
                var diller = await _mediator.Send(new GetByIdDillerQuery() { Id = id });

                fromCache = JsonSerializer.Serialize(diller);
                await _distributedCache.SetStringAsync($"Diller{diller.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<Diller>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllDiller()
        {

            var fromCache = await _distributedCache.GetStringAsync($"GetAllDiller");

            if (fromCache is null)
            {
                var diller = await _mediator.Send(new GetAllDillerQuery());

                fromCache = JsonSerializer.Serialize(diller);
                await _distributedCache.SetStringAsync($"GetAllDiller", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<Diller>>(fromCache);

            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateDiller(CreateDillerDto createDillerDto)
        {
            CreateDillerCommand diller = new CreateDillerCommand()
            {
                Region = createDillerDto.Region,
                Contact=createDillerDto.Contact
            };

            var result=await _mediator.Send(diller);

            return Ok(result);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateDiller(UpdateDillerDto updateDillerDto)
        {
            UpdateDillerCommand diller = new UpdateDillerCommand()
            {
                Id=updateDillerDto.Id,
                Region=updateDillerDto.Region,
                Contact=updateDillerDto.Contact,
            };

            var result = await _mediator.Send(diller);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteDiller(int id)
        {
            var result = await _mediator.Send(new DeleteDillerCommand() {Id=id});
            return Ok(result);
        }
    }
}

