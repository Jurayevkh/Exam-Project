using GeneralMotors.Application.UseCases.Clients.Queries;
using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Application.UseCases.Clients.Handlers;

public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, List<Client>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllClientQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Clients.ToListAsync(cancellationToken);
    }
}

