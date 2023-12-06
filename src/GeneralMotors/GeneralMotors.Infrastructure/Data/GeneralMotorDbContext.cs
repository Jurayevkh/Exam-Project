using System.Reflection;
using GeneralMotors.Application.Abstractions;
using GeneralMotors.Domain.Entities.Cars;
using GeneralMotors.Domain.Entities.CarTypes;
using GeneralMotors.Domain.Entities.Clients;
using GeneralMotors.Domain.Entities.Dillers;
using GeneralMotors.Domain.Entities.SuperAdmins;
using GeneralMotors.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GeneralMotors.Infrastructure.Data;

public class GeneralMotorDbContext:DbContext,IApplicationDbContext
{
    public GeneralMotorDbContext(DbContextOptions<GeneralMotorDbContext> options):base(options)
    {

    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<CarClient> CarClients { get; set; }
    public DbSet<Diller> Dillers { get; set; }
    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<CarType> CarTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartypeTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SuperAdminTypeConfiguration());
    }
}

