namespace GeneralMotors.Application.UseCases.Cars.Handlers;

public class CreateCarCommandHandler : AsyncRequestHandler<CreateCarCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCarCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    protected override async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = new Car()
        {
            Name = request.Name,
            Model = request.Model,
            Price = request.Price,
            Color = request.Color,
            Fuel_Type = request.Fuel_Type,
            Features = request.Features,
            Description = request.Description,
            CreatedAt=request.CreatedAt,
            CarTypeId = request.CarTypeId,
            CarImage = request.CarImage,
        };

        await _applicationDbContext.Cars.AddAsync(car);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
    }
}
