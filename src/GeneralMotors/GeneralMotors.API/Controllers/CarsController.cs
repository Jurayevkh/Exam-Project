namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCarAsync(int id)
        {
            var car = await _mediator.Send(new GetAllCarType() {Id=id});
      
            return Ok(car);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCarAsync()
        {
            var cars = await _mediator.Send(new GetAllCarQuery());
            return Ok(cars);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCar(CreateCarDto carDto)
        {
            CreateCarCommand car = new CreateCarCommand()
            {
                Name=carDto.Name,
                Model=carDto.Model,
                Price=carDto.Price,
                Color=carDto.Color,
                Fuel_Type=carDto.Fuel_Type,
                Features=carDto.Features,
                Description=carDto.Description,
                CreatedAt=DateTime.UtcNow,
                CarTypeId=carDto.CarTypeId,
                CarImage=carDto.CarImage
            };

            await _mediator.Send(car);
            return Ok("Created!");
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            UpdateAllColumnCarCommand car = new UpdateAllColumnCarCommand()
            {
            Id=updateCarDto.Id,
            Name = updateCarDto.Name,
            Model = updateCarDto.Model,
            Price = updateCarDto.Price,
            Color = updateCarDto.Color,
            Fuel_Type = updateCarDto.Fuel_Type,
            Features = updateCarDto.Features,
            Description = updateCarDto.Description,
            UpdatedAt=DateTime.UtcNow,
            CarTypeId = updateCarDto.CarTypeId,
            CarImage = updateCarDto.CarImage,
            };

            await _mediator.Send(car);

            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new DeleteCarCommand() {Id=id});

            return Ok("Deleted");
        }

    }
}

