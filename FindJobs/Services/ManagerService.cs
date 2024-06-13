
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation_Service;
using Services.Api_Service;
using Repositiries;

namespace Services
{
    public class ManagerService
    {
        public IFieldOfWorkService fieldOfWorkServices { get; }
        public IJobService jobServices { get; }
        public IEmployerService employerServices { get; }
        //.....

        public ManagerService()
        {
            ServiceCollection services = new();
            services.AddScoped<ManagerRepo>();

            services.AddScoped<IFieldOfWorkService, FieldOfWorkService>();
         
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEmployerService, EmployerService>();
            //.....
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            fieldOfWorkServices = (FieldOfWorkService) servicesProvider.GetService<IFieldOfWorkService>();
            employerServices= (EmployerService) servicesProvider.GetRequiredService<IEmployerService>();
            jobServices = (JobService)servicesProvider.GetService<IJobService>();
        }
    }
}
