namespace GeneralMotors.Application.UseCases.Dillers.Handlers;

public class GetAllDillerQueryHandler : IRequestHandler<GetAllDillerQuery, List<Diller>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDillerQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Diller>> Handle(GetAllDillerQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Dillers.ToListAsync(cancellationToken);

    }
}

