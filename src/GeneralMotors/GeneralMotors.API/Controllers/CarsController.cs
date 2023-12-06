namespace GeneralMotors.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public CarsController(IMediator mediator,IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCarAsync(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Car{id}");

            if(fromCache is null)
            {
                var car = await _mediator.Send(new GetByIdCarQuery() {Id=id});
           
                fromCache = JsonSerializer.Serialize(car);
                await _distributedCache.SetStringAsync($"Car{car.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow=TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<Car>(fromCache);

            return Ok(result);
        }


        [HttpGet]
        public async ValueTask<IActionResult> GetAllCarAsync()
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllCar");

            if(fromCache is null)
            {
                var cars = await _mediator.Send(new GetAllCarQuery());

                fromCache = JsonSerializer.Serialize(cars);
                await _distributedCache.SetStringAsync("GetAllCar", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<Car>>(fromCache);

            return Ok(result);
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

            var result=await _mediator.Send(car);
            return Ok(result);
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

            var result=await _mediator.Send(car);

            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCar(int id)
        {
            var result=await _mediator.Send(new DeleteCarCommand() {Id=id});

            return Ok(result);
        }

    }
}

