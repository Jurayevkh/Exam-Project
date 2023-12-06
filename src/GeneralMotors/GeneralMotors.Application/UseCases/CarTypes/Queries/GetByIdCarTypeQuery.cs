namespace GeneralMotors.Application.UseCases.CarTypes.Queries;

public class GetByIdCarTypeQuery:IRequest<CarType>
{
    public int Id { get; set; }
}

