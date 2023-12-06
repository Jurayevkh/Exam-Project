using GeneralMotors.Application.UseCases.Clients.Commands;
using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Application.UseCases.Clients.Handlers;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateClientCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Client client = new Client()
            {
                FullName = request.FullName,
                Contact = request.Contact,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                Address = request.Address,
                Role = request.Role
            
            };

            await _applicationDbContext.Clients.AddAsync(client);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

