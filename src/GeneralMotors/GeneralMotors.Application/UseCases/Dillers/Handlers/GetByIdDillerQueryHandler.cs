namespace GeneralMotors.Application.UseCases.Dillers.Handlers;

public class GetByIdDillerQueryHandler : IRequestHandler<GetByIdDillerQuery, Diller>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdDillerQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Diller> Handle(GetByIdDillerQuery request, CancellationToken cancellationToken)
    {
        var diller = await _applicationDbContext.Dillers.FirstOrDefaultAsync(dil => dil.Id == request.Id);

        return diller;
    }
}

