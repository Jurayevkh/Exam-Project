namespace GeneralMotors.Application.UseCases.Cars.Handlers;


public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCarCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        try
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
                CreatedAt = request.CreatedAt,
                CarTypeId = request.CarTypeId,
                CarImage = request.CarImage,
            };
            await _applicationDbContext.Cars.AddAsync(car);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }

}
}







