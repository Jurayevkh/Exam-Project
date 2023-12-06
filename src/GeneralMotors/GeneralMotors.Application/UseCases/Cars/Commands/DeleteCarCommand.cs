namespace GeneralMotors.Application.UseCases.Cars.Commands;

public class DeleteCarCommand:IRequest<bool>
{
    public int Id { get; set; }
}

