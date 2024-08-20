using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using Microsoft.Extensions.Configuration;
using Services.ApiService;
using Services.ImplementationService;

namespace Services
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register repositories
            services.AddRepositories();

            // Register services
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IFieldsOfWorkService, FieldsOfWorkService>();

            // Register DbContext with SQL Server
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile)); // Assuming you have a MappingProfile class

            return services;
        }
    }
}
