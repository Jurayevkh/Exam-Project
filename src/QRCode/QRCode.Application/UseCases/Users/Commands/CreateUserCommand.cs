namespace QRCode.Application.UseCases.Users.Commands;

public class CreateUserCommand:IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

