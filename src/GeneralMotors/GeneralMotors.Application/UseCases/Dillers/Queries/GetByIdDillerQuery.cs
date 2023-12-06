namespace GeneralMotors.Application.UseCases.Dillers.Queries;

public class GetByIdDillerQuery:IRequest<Diller>
{
    public int Id { get; set; }
}

