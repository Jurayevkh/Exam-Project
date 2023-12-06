namespace GeneralMotors.Application.UseCases.Clients.Commands;

public class DeleteClientCommand:IRequest<bool>
{
    public int Id { get; set; }
}

