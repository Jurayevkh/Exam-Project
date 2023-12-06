namespace GeneralMotors.Application.UseCases.Dillers.Handlers;

public class DeleteDillerCommandHandler:IRequestHandler<DeleteDillerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteDillerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteDillerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var diller = _applicationDbContext.Dillers.FirstOrDefault(dil=>dil.Id==request.Id);

            if (diller is null)
                return false;

            _applicationDbContext.Dillers.Remove(diller);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

