using HRSolutions.UseCases.Interfaces;
using HRSolutions.DataAccess.Implementations;
using HRSolutions.DataAccess.Persistence;
using HRSolutions.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HRSolutions.DataAccess.Models;
using Microsoft.Extensions.Configuration;


namespace HRSolutions.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static void AddDataAccess(this IServiceCollection services, Action<DatabaseConfiguration> databaseConfigurator)
        {
            var config = new DatabaseConfiguration();
            databaseConfigurator(config);

            services.AddDbContext<HRSolutionsContext>(options =>
                options.UseSqlServer(config.ConnectionString,
                    opt => opt.MigrationsAssembly(typeof(HRSolutionsContext).Assembly.FullName)));
            services.AddScoped<HRSolutionsContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }


   

}
