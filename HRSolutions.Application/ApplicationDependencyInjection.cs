using HRSolutions.Application.UseCases;
using HRSolutions.Domain.Entities;
using HRSolutions.Domain.Services;
using HRSolutions.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRSolutions.Application
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var mediatRAssemblies = new[]
{
              Assembly.GetAssembly(typeof(Employee)), // Domain
              Assembly.GetAssembly(typeof(CreateEmployeeCommand))
            };
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));

            services.AddScoped<EmployeeService>();

        }
    }
}
