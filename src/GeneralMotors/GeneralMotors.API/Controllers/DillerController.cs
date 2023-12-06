
using GeneralMotors.API.DTOs.Dillers;
using GeneralMotors.Application.UseCases.Dillers.Commands;
using GeneralMotors.Application.UseCases.Dillers.Queries;

namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DillerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DillerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdDiller(int id)
        {
            var diller = await _mediator.Send(new GetByIdDillerQuery() { Id = id });

            return Ok(diller);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllDiller()
        {
            var diller = await _mediator.Send(new GetAllDillerQuery());

            return Ok(diller);
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

