using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheHopeless.API.Database;

namespace TheHopeless.API.Configurations
{
    public static class StartupExtentions
    {

        public static void SetUpDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Database:ConnectionString"];
            services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));
        }
        public static void SetUpAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperConfiguration());
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

    }
}
