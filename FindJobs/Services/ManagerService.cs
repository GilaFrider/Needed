
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
        public ICriterionService criterionService { get; }

        //.....

        public ManagerService()
        {
            ServiceCollection services = new();
            services.AddScoped<ManagerRepo>();

            services.AddScoped<IFieldOfWorkService, FieldOfWorkService>();
         
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ICriterionService, CriterionService>();
            //.....
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            fieldOfWorkServices = (FieldOfWorkService) servicesProvider.GetService<IFieldOfWorkService>();
            employerServices= (EmployerService) servicesProvider.GetRequiredService<IEmployerService>();
            criterionService =(CriterionService) servicesProvider.GetRequiredService<ICriterionService>();
            jobServices = (JobService)servicesProvider.GetService<IJobService>();
        }
    }
}
