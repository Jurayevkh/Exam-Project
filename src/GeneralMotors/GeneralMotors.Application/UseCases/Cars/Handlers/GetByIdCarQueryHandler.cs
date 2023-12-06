using GeneralMotors.Application.UseCases.Cars.Queries;
using Microsoft.EntityFrameworkCore;

namespace GeneralMotors.Application.UseCases.Cars.Handlers;

public class GetByIdCarQueryHandler : IRequestHandler<GetAllCarType,Car>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdCarQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Car> Handle(GetAllCarType request, CancellationToken cancellationToken)
    {
        var car = await _applicationDbContext.Cars.FirstOrDefaultAsync(car=>car.Id==request.Id);

        return car;
    }
}

