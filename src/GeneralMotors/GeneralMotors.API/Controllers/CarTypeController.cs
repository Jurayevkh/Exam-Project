using GeneralMotors.Application.UseCases.CarTypes.Queries;

namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCarType()
        {
            var carType = await _mediator.Send(new GetAllCarTypesQuery());

            return Ok(carType);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCarType(int id)
        {
            var carType = await _mediator.Send(new GetByIdCarTypeQuery() { Id = id });

            return Ok(carType);
        }

    }
}

