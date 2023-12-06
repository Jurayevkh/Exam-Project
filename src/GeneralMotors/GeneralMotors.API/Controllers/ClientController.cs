using GeneralMotors.API.DTOs.Clients;
using GeneralMotors.Application.UseCases.Clients.Commands;
using GeneralMotors.Application.UseCases.Clients.Queries;
namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllClients()
        {
            var clients = await _mediator.Send(new GetAllClientQuery());

            return Ok(clients);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdClients(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery() { Id = id });

            return Ok(client);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateClient(CreateClientDto createClientDto)
        {
            CreateClientCommand client = new CreateClientCommand()
            {
                FullName=createClientDto.FullName,
                Contact=createClientDto.Contact,
                UserName=createClientDto.UserName,
                Password=createClientDto.Password,
                Email=createClientDto.Email,
                Address=createClientDto.Address,
            
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

