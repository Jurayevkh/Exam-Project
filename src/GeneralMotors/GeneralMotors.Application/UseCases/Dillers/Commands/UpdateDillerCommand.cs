namespace GeneralMotors.Application.UseCases.Dillers.Commands;

public class UpdateDillerCommand:IRequest<bool>
{
    public int Id { get; set; }
    public string Region { get; set; }
    public string Contact { get; set; }
}

