namespace GeneralMotors.Application.UseCases.Dillers.Handlers;

public class UpdateDillerCommandHandler:IRequestHandler<UpdateDillerCommand,bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateDillerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateDillerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var diller = _applicationDbContext.Dillers.FirstOrDefault(dil=>dil.Id==request.Id);
            if(diller is null)
                return false;
            diller.Region = request.Region;
            diller.Contact = request.Contact;
            _applicationDbContext.Dillers.Update(diller);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

