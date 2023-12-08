namespace QRCode.Infrastructure.Data;

public class QRCodeDbContext :DbContext, IApplicationDbContext
{
    public QRCodeDbContext(DbContextOptions<QRCodeDbContext> options):base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

