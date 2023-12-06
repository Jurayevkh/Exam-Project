using System.Net;
using GeneralMotors.Application.UseCases.Clients.Commands;
using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Application.UseCases.Clients.Handlers;

public class UpdateClientCommandHandler:IRequestHandler<UpdateClientCommand,bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateClientCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Client client = _applicationDbContext.Clients.FirstOrDefault(cl=>cl.Id==request.Id);
            if (client is null)
                return false;

            client.FullName = request.FullName;
            client.Contact = request.Contact;
            client.UserName = request.UserName;
            client.Password = request.Password;
            client.Email = request.Email;
            client.Address = request.Address;

            _applicationDbContext.Clients.Update(client);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }

    }
}

