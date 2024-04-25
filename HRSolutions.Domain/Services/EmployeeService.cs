using HRSolutions.Domain.Entities;
using HRSolutions.UseCases.Interfaces;

namespace HRSolutions.Domain.Services
{
    public class EmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;

        public EmployeeService(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> IsIdUnique(string employeeId)
        {
            var existingEmployee = await _employeeRepository.GetFirstAsync(employee => employee.EmployeeId.Equals(employeeId));
            return existingEmployee == null;
        }

        public async Task<bool> EmployeeExists(string employeeId)
        {
            var existingEmployee = await _employeeRepository.GetFirstAsync(employee => employee.EmployeeId.Equals(employeeId));
            return existingEmployee != null;
        }

        public bool IsValidBirthDate(DateOnly birthdate)
        {
            return birthdate <= DateOnly.FromDateTime(DateTime.UtcNow.Date);
        }

    }
}
