namespace GeneralMotors.Application.UseCases.Dillers.Commands;

public class DeleteDillerCommand:IRequest<bool>
{
	public int Id { get; set; }
}

