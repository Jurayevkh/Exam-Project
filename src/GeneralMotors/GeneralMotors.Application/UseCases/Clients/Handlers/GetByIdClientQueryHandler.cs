using GeneralMotors.Application.UseCases.Clients.Queries;
using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Application.UseCases.Clients.Handlers;

public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, Client>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdClientQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Client> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
    {
        var client = await _applicationDbContext.Clients.FirstOrDefaultAsync(cl => cl.Id == request.Id);

        return client;
    }
}

