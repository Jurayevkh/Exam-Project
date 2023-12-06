using GeneralMotors.Application.UseCases.Cars.Queries;
using Microsoft.EntityFrameworkCore;

namespace GeneralMotors.Application.UseCases.Cars.Handlers;

public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery,List<Car>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCarQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Cars.ToListAsync(cancellationToken);
    }
}

