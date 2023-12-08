namespace QRCode.Application.Abstractions;

public interface IApplicationDbContext
{ 
    public DbSet<User> Users { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

