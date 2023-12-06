using System.Threading;
using GeneralMotors.Application.UseCases.Clients.Commands;
using MediatR;

namespace GeneralMotors.Application.UseCases.Clients.Handlers;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteClientCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var client = _applicationDbContext.Clients.FirstOrDefault(cl=>cl.Id==request.Id);

            if (client is null)
                return false;

            _applicationDbContext.Clients.Remove(client);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }


}

