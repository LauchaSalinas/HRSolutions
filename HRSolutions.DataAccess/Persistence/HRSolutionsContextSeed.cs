using HRSolutions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HRSolutions.DataAccess.Persistence
{
    public static class HRSolutionsContextSeed
    {
        private static Employee _employee1 = new() { BirthDate = new DateOnly(1995, 12, 13), FullName = "Ezekiel Creimerman", EmployeeId = "HRS0001" };
        private static Employee _employee2 = new() { BirthDate = new DateOnly(1996, 01, 14), FullName = "Marie Abadie", EmployeeId = "HRS0002" };
        private static Employee _employee3 = new() { BirthDate = new DateOnly(1994, 11, 12), FullName = "Lautaro David Salinas", EmployeeId = "HRS0003" };
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new HRSolutionsContext(serviceProvider.GetRequiredService<DbContextOptions<HRSolutionsContext>>()))
            {
                if (dbContext.Employees.Any()) return;

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(HRSolutionsContext dbContext)
        {
            foreach (var employee in dbContext.Employees)
            {
                dbContext.Remove(employee);
            }
            dbContext.SaveChanges();

            dbContext.Employees.Add(_employee1);
            dbContext.Employees.Add(_employee2);
            dbContext.Employees.Add(_employee3);

            dbContext.SaveChanges();
        }
    }
}
