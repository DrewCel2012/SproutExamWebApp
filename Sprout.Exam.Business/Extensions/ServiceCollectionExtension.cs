using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.DataAccess.Interface;
using Sprout.Exam.DataAccess.UnitOfWork;

namespace Sprout.Exam.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void DependencyInjectionComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
