using GeneralMotors.Domain.Entities.Clients;
using GeneralMotors.Domain.Entities.SuperAdmins;

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

