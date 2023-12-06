namespace GeneralMotors.API.DTOs.Clients;

public class CreateClientDto
{
    public string FullName { get; set; }
    public string Contact { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}

