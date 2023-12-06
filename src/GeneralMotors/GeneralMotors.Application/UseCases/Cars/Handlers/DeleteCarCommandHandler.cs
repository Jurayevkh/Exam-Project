namespace GeneralMotors.Application.UseCases.Cars.Handlers;


public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteCarCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var car = _applicationDbContext.Cars.FirstOrDefault(car => car.Id == request.Id);
            _applicationDbContext.Cars.Remove(car);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}





