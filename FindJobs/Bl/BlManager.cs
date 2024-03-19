using Bl.Bl_Api;
using Bl.Bl_Implementation;
using DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BlManager
    {
        public IBlFieldOfWork fieldOfWorkServices { get; }
        //.....

        public BlManager()
        {
            ServiceCollection services = new();
            services.AddScoped<DalManager>();

            services.AddScoped<IBlFieldOfWork, BlFieldOfWork>();
            //.....
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            fieldOfWorkServices = servicesProvider.GetService<IBlFieldOfWork>();
        }
    }
}
