namespace QRCode.Application.UseCases.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            User user = new User()
            {
                FirstName=request.FirstName,
                LastName=request.LastName,
                MiddleName=request.MiddleName,
                Age=request.Age,
                Email=request.Email

            };

            await _applicationDbContext.Users.AddAsync(user);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

