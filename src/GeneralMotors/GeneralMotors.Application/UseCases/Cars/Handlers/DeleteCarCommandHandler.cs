namespace GeneralMotors.Application.UseCases.Cars.Handlers;

public class DeleteCarCommandHandler : AsyncRequestHandler<DeleteCarCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteCarCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    protected override async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = _applicationDbContext.Cars.FirstOrDefault(car=>car.Id==request.Id);
        _applicationDbContext.Cars.Remove(car);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}

