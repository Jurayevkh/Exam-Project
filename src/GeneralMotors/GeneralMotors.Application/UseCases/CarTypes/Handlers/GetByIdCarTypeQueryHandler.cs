namespace GeneralMotors.Application.UseCases.CarTypes.Handlers;

public class GetByIdCarTypeQueryHandler : IRequestHandler<GetByIdCarTypeQuery, CarType>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdCarTypeQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<CarType> Handle(GetByIdCarTypeQuery request, CancellationToken cancellationToken)
    {
        var carType = await _applicationDbContext.CarTypes.FirstOrDefaultAsync(cartype => cartype.Id == request.Id);

        return carType;
    }
}

