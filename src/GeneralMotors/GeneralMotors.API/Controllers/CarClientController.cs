using GeneralMotors.API.DTOs.CarClient;
using GeneralMotors.Application.UseCases.CarClients.Commands;
using GeneralMotors.Domain.Entities.Cars;

namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarClientController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}

