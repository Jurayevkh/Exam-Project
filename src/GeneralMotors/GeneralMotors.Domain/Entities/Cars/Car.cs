using GeneralMotors.Domain.Entities.CarTypes;

namespace GeneralMotors.Domain.Entities.Cars;

public class Car:BaseEntity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }
    public string Fuel_Type { get; set; }
    public string Features { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public string CarImage { get; set; }

#region relation
    public int CarTypeId { get; set; }
    public CarType CarType { get; set; }

    public ICollection<CarClient> CarClients { get; set; }
#endregion
}

