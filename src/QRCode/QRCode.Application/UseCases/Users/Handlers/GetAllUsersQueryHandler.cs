namespace QRCode.Application.UseCases.Users.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<User>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Users.ToListAsync(cancellationToken);
    }
}

