using Bl.Bl_Api;
using Bl.Bl_Implementation;
using DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BlManager
    {
        public IBlFieldOfWork fieldOfWorkServices { get; }
        public IBlJob jobServices { get; }
        public IBlEmployer employerServices { get; }
        //.....

        public BlManager()
        {
            ServiceCollection services = new();
            services.AddScoped<DalManager>();

            services.AddScoped<IBlFieldOfWork, BlFieldOfWork>();
         
            services.AddScoped<IBlJob, BlJob>();
            services.AddScoped<IBlEmployer, BlEmployer>();
            //.....
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            fieldOfWorkServices = (BlFieldOfWork) servicesProvider.GetService<IBlFieldOfWork>();
            employerServices= (BlEmployer) servicesProvider.GetRequiredService<IBlEmployer>();
            jobServices = (BlJob)servicesProvider.GetService<IBlJob>();
        }
    }
}
