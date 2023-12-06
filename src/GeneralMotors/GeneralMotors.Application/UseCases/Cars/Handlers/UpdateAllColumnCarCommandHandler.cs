namespace GeneralMotors.Application.UseCases.Cars.Handlers;

public class UpdateAllColumnCarCommandHandler : AsyncRequestHandler<UpdateAllColumnCarCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateAllColumnCarCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    protected override async Task Handle(UpdateAllColumnCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _applicationDbContext.Cars.FirstOrDefault(car=>car.Id==request.Id);

        car.Name = request.Name;
        car.Model = request.Model;
        car.Price = request.Price;
        car.Color = request.Color;
        car.Fuel_Type = request.Fuel_Type;
        car.Features = request.Features;
        car.Description = request.Description;
        car.CarTypeId = request.CarTypeId;
        car.CarImage = request.CarImage;

        _applicationDbContext.Cars.Update(car);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}

