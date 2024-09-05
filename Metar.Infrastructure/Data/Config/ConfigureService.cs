using MetarApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetarApi.Data.Config
{
    public static class ConfigureService
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MetarDbContext>(option => option.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MetarEntity));

            return services;
        }
    }
}
