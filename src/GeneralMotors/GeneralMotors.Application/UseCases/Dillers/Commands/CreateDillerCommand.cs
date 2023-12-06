namespace GeneralMotors.Application.UseCases.Dillers.Commands;

public class CreateDillerCommand:IRequest<bool>
{
    public string Region { get; set; }
    public string Contact { get; set; }
}

