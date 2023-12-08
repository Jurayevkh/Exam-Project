namespace QRCode.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} ,FirstName: {FirstName} ,LastName: {LastName} ,MiddleName {MiddleName} ,Age: {Age} ,Email: {Email} ";
    } 
}

