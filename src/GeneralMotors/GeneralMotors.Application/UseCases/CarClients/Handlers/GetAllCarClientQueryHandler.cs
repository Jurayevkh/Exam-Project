using GeneralMotors.Application.UseCases.CarClients.Queries;

namespace GeneralMotors.Application.UseCases.CarClients.Handlers;

public class GetAllCarClientQueryHandler : IRequestHandler<GetAllCarClientQuery, List<CarClient>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCarClientQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<CarClient>> Handle(GetAllCarClientQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.CarClients.ToListAsync(cancellationToken);

    }
}

