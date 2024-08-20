using Microsoft.Extensions.DependencyInjection;
using Repositories.ImplementationRepo;
using Repositories.ApiRepo;
using System.Text;

namespace Repositories
{
    public static class ServicesRepositoriesCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register your repositories here
            services.AddScoped<IEmployerRepo, EmployerRepo>();
            services.AddScoped<IJobRepo, JobRepo>();
            services.AddScoped<IFieldsOfWorkRepo, FieldsOfWorkRepo>();

            return services;
        }

        // Example utility method for converting object properties to a string
        public static string ToStringProperties<T>(this T obj)
        {
            var properties = obj.GetType().GetProperties();
            var result = new StringBuilder();

            foreach (var property in properties)
            {
                result.Append($"{property.Name}: {property.GetValue(obj)}");

                if (property.PropertyType.IsArray)
                {
                    var array = (Array)property.GetValue(obj);
                    if (array != null)
                    {
                        result.Append($"[{string.Join(", ", array.Cast<object>())}]");
                    }
                }

                result.Append(", ");
            }

            return result.ToString().TrimEnd(',', ' ');
        }
    }
}
