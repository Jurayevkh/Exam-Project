using GeneralMotors.Application.UseCases.CarClients.Queries;

namespace GeneralMotors.Application.UseCases.CarClients.Handlers;

public class GetByIdCarClientQueryHandler : IRequestHandler<GetByIdCarClientQuery, CarClient>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdCarClientQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<CarClient> Handle(GetByIdCarClientQuery request, CancellationToken cancellationToken)
    {
        var carclient = await _applicationDbContext.CarClients.FirstOrDefaultAsync(carcl => carcl.Id == request.Id);

        return carclient;
    }
}

