namespace GeneralMotors.Application.UseCases.Cars.Queries;

public class GetByIdCarQuery:IRequest<Car>
{
    public int Id { get; set; }
}

