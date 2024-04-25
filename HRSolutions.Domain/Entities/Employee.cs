using HRSolutions.Domain.Interfaces;

namespace HRSolutions.Domain.Entities
{
    public class Employee : IBaseEntity , IAggregateRoot
    {
        public required DateOnly BirthDate { get; set; }
        public required string FullName { get; set; }
        public required string EmployeeId { get; set; }
    }
}
