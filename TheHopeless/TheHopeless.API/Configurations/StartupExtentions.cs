using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
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
        public static void ConfigureAndUseSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "version_demo");
                c.SwaggerEndpoint("/swagger/demo/swagger.json", "Xplicity");
                c.RoutePrefix = "swagger";
            });
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("demo", new Info { Title = "TournamentApp demo", Version = "v1" });
            });

            return services;
        }

    }
}
