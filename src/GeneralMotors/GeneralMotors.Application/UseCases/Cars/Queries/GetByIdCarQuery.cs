namespace GeneralMotors.Application.UseCases.Cars.Queries;

public class GetAllCarType:IRequest<Car>
{
    public int Id { get; set; }
}

