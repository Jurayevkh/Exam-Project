namespace GeneralMotors.Application.UseCases.Clients.Commands;

public class CreateClientCommand:IRequest<bool>
{
    public string FullName { get; set; }
    public string Contact { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Role { get; set; } = "Client";
}

