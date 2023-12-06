namespace GeneralMotors.Application.UseCases.Cars.Commands;

public class DeleteCarCommand:IRequest
{
    public int Id { get; set; }
}

