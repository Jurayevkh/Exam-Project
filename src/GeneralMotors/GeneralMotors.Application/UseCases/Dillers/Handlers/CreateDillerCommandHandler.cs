namespace GeneralMotors.Application.UseCases.Dillers.Handlers;

public class CreateDillerCommandHandler : IRequestHandler<CreateDillerCommand,bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateDillerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateDillerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Diller diller = new Diller()
            {
                Region = request.Region,
                Contact = request.Contact
            };

            await _applicationDbContext.Dillers.AddAsync(diller);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
          return false;
        }


    }
}

