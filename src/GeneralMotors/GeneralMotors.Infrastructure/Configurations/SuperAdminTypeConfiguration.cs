namespace GeneralMotors.Infrastructure.Configurations;

public class SuperAdminTypeConfiguration : IEntityTypeConfiguration<SuperAdmin>
{
    public void Configure(EntityTypeBuilder<SuperAdmin> builder)
    {
        builder.HasData(
            new SuperAdmin { Id=1,Name="Rustambek Jo'rayev",UserName="rustam",Password="qwerty123"},
            new SuperAdmin { Id=2,Name="Bahriddin Abdusalomov",UserName="baxa_tashkentskiy",Password="BaxaKriminal"}
            );
    }
}

