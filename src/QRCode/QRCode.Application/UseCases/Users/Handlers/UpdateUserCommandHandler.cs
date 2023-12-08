namespace QRCode.Application.UseCases.Users.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            User user = _applicationDbContext.Users.FirstOrDefault(user=>user.Id==request.Id);
            if (user is null)
                return false;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddleName = request.MiddleName;
            user.Age = request.Age;
            user.Email = request.Email;

            _applicationDbContext.Users.Update(user);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

