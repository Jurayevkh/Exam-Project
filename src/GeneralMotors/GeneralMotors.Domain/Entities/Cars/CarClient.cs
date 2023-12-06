using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Domain.Entities.Cars;

public class CarClient:BaseEntity
{
    public int CarId { get; set; }
    public Car Car { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}

