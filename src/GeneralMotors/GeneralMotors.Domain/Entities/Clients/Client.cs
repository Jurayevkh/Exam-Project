using GeneralMotors.Domain.Entities.Cars;

namespace GeneralMotors.Domain.Entities.Clients;

public class Client:BaseEntity
{
    public string FullName { get; set; }
    public string Contact { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Role { get; set; }

    #region relation
    public ICollection<CarClient>? CarClients { get; set; }
    #endregion
}

