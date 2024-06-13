using Repositiries.Api_Repo;
using Repositiries.Implementation_Repo;
using Repositiries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repositiries
{
    public class ManagerRepo
    {
        public EmployerRepo employer { get;}
        public CriterionRepo criterion { get;}
        public FieldOfWorkRepo fieldOfWork { get;}
        public JobRepo job { get;}
        public ManagerRepo()
        {
            //string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0}\\DataBase\\Data.mdf\";Integrated Security=True;Connect Timeout=30";
            ServiceCollection services = new();
            services.AddDbContext<Context>(/*opt => opt.UseSqlServer(strconn)*/);
            services.AddScoped<IEmployerRepo, EmployerRepo>();  
            services.AddScoped<ICriterionRepo, CriterionRepo>();
            services.AddScoped<IFieldOfWorkRepo, FieldOfWorkRepo>();
            services.AddScoped<IJobRepo, JobRepo>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            employer = (EmployerRepo)serviceProvider.GetRequiredService<IEmployerRepo>();
            criterion = (CriterionRepo)serviceProvider.GetRequiredService<ICriterionRepo>();
            fieldOfWork = (FieldOfWorkRepo)serviceProvider.GetRequiredService<IFieldOfWorkRepo>();
            job = (JobRepo)serviceProvider.GetRequiredService<IJobRepo>();


        }

    }
}