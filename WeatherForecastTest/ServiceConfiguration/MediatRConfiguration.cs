//using HRSolutions.UseCases.Models;
//using HRSolutions.Domain.Entities;
//using System.Reflection;

//namespace HRSolutions.API.ServiceConfiguration
//{
//    internal static class MediatRConfiguration
//    {
//        internal static void ConfigureMediatR(this IServiceCollection services)
//        {
//            var mediatRAssemblies = new[]
//            {
//              Assembly.GetAssembly(typeof(Employee)), // Domain
//              Assembly.GetAssembly(typeof(CreateEmployeeCommand))
//            };
//            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
//        }
//    }
//}
