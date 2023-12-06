using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public ClientController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllClients()
        {
            var fromCache = await _distributedCache.GetStringAsync($"GetAllClient");

            if (fromCache is null)
            {
                var client = await _mediator.Send(new GetAllClientQuery());

                fromCache = JsonSerializer.Serialize(client);
                await _distributedCache.SetStringAsync($"GetAllClient", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<Client>>(fromCache);

            return Ok(result);
        }
    
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdClients(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Client{id}");

            if (fromCache is null)
            {
                var client = await _mediator.Send(new GetByIdClientQuery() { Id = id });

                fromCache = JsonSerializer.Serialize(client);
                await _distributedCache.SetStringAsync($"Client{client.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<Client>(fromCache);

            return Ok(result);
      
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateClient(CreateClientDto createClientDto)
        {
            CreateClientCommand client = new CreateClientCommand()
            {
                FullName = createClientDto.FullName,
                Contact = createClientDto.Contact,
                UserName = createClientDto.UserName,
                Password = createClientDto.Password,
                Email = createClientDto.Email,
                Address = createClientDto.Address,
                Role = "client",
            
            };
            var result = await _mediator.Send(client);

            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateClient(UpdateClientDto updateClientDto)
        {
            UpdateClientCommand client = new UpdateClientCommand()
            {
                Id = updateClientDto.Id,
                FullName = updateClientDto.FullName,
                Contact = updateClientDto.Contact,
                UserName = updateClientDto.UserName,
                Password = updateClientDto.Password,
                Email = updateClientDto.Email,
                Address = updateClientDto.Address,
                Role=updateClientDto.Role
            };

            var result = await _mediator.Send(client);

            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClient(int id)
        {
            var result = await _mediator.Send(new DeleteClientCommand() { Id = id });
            return Ok(result);
        }
    }
}

