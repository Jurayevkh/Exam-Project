using GeneralMotors.Domain.Entities.CarTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralMotors.Infrastructure.Configurations;

public class CartypeTypeConfiguration : IEntityTypeConfiguration<CarType>
{
    public void Configure(EntityTypeBuilder<CarType> builder)
    {
        builder.HasData(
            new CarType {Id=1,Type="Sedan"},
            new CarType {Id=2,Type="Kupe"},
            new CarType {Id=3,Type="universal"},
            new CarType {Id=4,Type="hetchbek" },
            new CarType {Id=5,Type="liftbek" },
            new CarType {Id=6,Type="limuzin" },
            new CarType {Id=7,Type="kabriolet" },
            new CarType {Id=8,Type="pikap" },
            new CarType {Id=9,Type="SUV" }
            );
    }
}

