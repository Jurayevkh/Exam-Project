using GeneralMotors.Domain.Entities.Cars;

namespace GeneralMotors.Domain.Entities.CarTypes;

public class CarType:BaseEntity
{
    public string Type { get; set; }

    #region relation
    public Car Car { get; set; }
    #endregion
}

