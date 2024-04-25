using HRSolutions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HRSolutions.DataAccess.Persistence;
using HRSolutions.DataAccess.Implementations;

namespace HRSolutions.Domain.Services.UnitTests
{
    [TestClass()]
    public class EmployeeServiceUnitTests
    {
        private DbContextOptions<HRSolutionsContext>? _options;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<HRSolutionsContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            using (var context = new HRSolutionsContext(_options))
            {
                HRSolutionsContextSeed.PopulateTestData(context);
            }
        }

        [TestMethod()]
        public async Task IsEmployeeIdUnique_ShouldReturnTrue_WhenEmployeeDoesNotExist()
        {
            using (var context = new HRSolutionsContext(_options!))
            {
                var service = new EmployeeService(new BaseRepository<Employee>(context));

                var result = await service.IsIdUnique("HRS0004");

                Assert.IsTrue(result);
            }
        }

        [TestMethod()]
        public async Task IsEmployeeIdUnique_ShouldReturnFalse_WhenEmployeeExists()
        {
            using (var context = new HRSolutionsContext(_options!))
            {
                var service = new EmployeeService(new BaseRepository<Employee>(context));

                var result = await service.IsIdUnique("HRS0001");

                Assert.IsFalse(result);
            }
        }
    }
}