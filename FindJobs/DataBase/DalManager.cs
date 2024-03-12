using DataBase.Dal_Api;
using DataBase.Dal_Implementation;
using DataBase.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public class DalManager
    {
        public EmployerRepo employer { get;}
        public CriterionRepo criterion { get;}
        public FieldOfWorkRepo fieldOfWork { get;}
        public JobRepo job { get;}
        public DalManager()
        {
            ServiceCollection services = new();
            services.AddDbContext<Context>();
            services.AddScoped<IEmployerRepo, EmployerRepo>();  
            services.AddScoped<ICriterionRepo, CriterionRepo>();
            services.AddScoped<IFieldOfWorkRepo, FieldOfWorkRepo>();
            services.AddScoped<IJobRepo, JobRepo>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            employer = serviceProvider.GetRequiredService<EmployerRepo>();
            criterion = serviceProvider.GetRequiredService<CriterionRepo>();
            fieldOfWork = serviceProvider.GetRequiredService<FieldOfWorkRepo>();
            job = serviceProvider.GetRequiredService<JobRepo>();


        }

    }
}