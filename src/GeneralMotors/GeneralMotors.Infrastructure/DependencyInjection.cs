using GeneralMotors.Application.Abstractions;
using GeneralMotors.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeneralMotors.Infrastructure;

public static class DependencyInjection
{ 
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext,GeneralMotorDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });

        return services;
    }
}

