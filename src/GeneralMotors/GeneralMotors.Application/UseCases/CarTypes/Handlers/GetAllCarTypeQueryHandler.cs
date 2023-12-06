namespace GeneralMotors.Application.UseCases.CarTypes.Handlers;

public class GetAllCarTypeQueryHandler : IRequestHandler<GetAllCarTypesQuery, List<CarType>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCarTypeQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<CarType>> Handle(GetAllCarTypesQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.CarTypes.ToListAsync(cancellationToken);
    }
}

