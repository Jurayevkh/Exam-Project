namespace GeneralMotors.Application.UseCases.CarClients.Commands;

public class CreateCarClientCommand:IRequest<bool>
{
    public int CarId { get; set; }
    public string UserName { get; set; }
}

