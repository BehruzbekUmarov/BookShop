using Book.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Book.Web.Extansions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("conn"));
        });
        return services;
    }

    //public static IServiceCollection AddMapper(IServiceCollection services)
    //{

    //}
}
