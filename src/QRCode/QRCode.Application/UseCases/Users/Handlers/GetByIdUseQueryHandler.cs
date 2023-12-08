namespace QRCode.Application.UseCases.Users.Handlers;

public class GetByIdUseQueryHandler : IRequestHandler<GetByIdUserQuery, User>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByIdUseQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Id == request.Id);

        return user;
    }
}

