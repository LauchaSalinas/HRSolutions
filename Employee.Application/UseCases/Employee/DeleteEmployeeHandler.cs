using HRSolutions.UseCases.Interfaces;
using HRSolutions.Domain.Entities;
using MediatR;
using HRSolutions.Application.Models;
using HRSolutions.Domain.Errors;
using HRSolutions.Domain.Services;

namespace HRSolutions.UseCases.Models
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeResponse>
    {
        IBaseRepository<Employee> _repository;
        EmployeeService _employeeService;
        public DeleteEmployeeHandler(IBaseRepository<Employee> repository, EmployeeService employeeService)
        {
            _repository = repository;
            _employeeService = employeeService;
        }

        public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeExists = await _employeeService.EmployeeExists(request.Request.EmployeeId);
            if (employeeExists)
            {
                return new DeleteEmployeeResponse() { Status = StatusResponse.Conflict, Errors = [EntityErrors.Duplicated] };
            }

            var deletedEmployee = await _repository.DeleteAsync(entity => entity.EmployeeId == request.Request.EmployeeId );

            return new DeleteEmployeeResponse() { Status = StatusResponse.Ok};
        }
    }
}
