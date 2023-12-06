using GeneralMotors.Application.UseCases.CarClients.Commands;

namespace GeneralMotors.Application.UseCases.CarClients.Handlers;

public class CreateCarClientCommandHandler : IRequestHandler<CreateCarClientCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCarClientCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateCarClientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var client = await _applicationDbContext.Clients.FirstOrDefaultAsync(cl=>cl.UserName==request.UserName);

            if (client is null)
                return false;

            CarClient carClient = new CarClient()
            {
                ClientId=client.Id,
                CarId=request.CarId
            };

            await _applicationDbContext.CarClients.AddAsync(carClient);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
   
}

