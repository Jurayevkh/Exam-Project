namespace GeneralMotors.Application.UseCases.CarClients.Queries;

public class GetByIdCarClientQuery:IRequest<CarClient>
{
    public int Id { get; set; }
}

