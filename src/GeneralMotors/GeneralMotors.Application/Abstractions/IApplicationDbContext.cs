using GeneralMotors.Domain.Entities.Cars;
using GeneralMotors.Domain.Entities.CarTypes;
using GeneralMotors.Domain.Entities.Clients;
using GeneralMotors.Domain.Entities.Dillers;
using GeneralMotors.Domain.Entities.SuperAdmins;
using Microsoft.EntityFrameworkCore;

namespace GeneralMotors.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Diller> Dillers { get; set; }
    public DbSet<CarClient> CarClients { get; set; }
    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<CarType> CarTypes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);

}

