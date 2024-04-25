using HRSolutions.Application.Models;
using HRSolutions.Domain.Entities;
using HRSolutions.Domain.Errors;
using HRSolutions.Domain.Services;
using HRSolutions.UseCases.Interfaces;
using HRSolutions.UseCases.Models;
using MediatR;

namespace HRSolutions.Application.UseCases
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
    {
        IBaseRepository<Employee> _repository;
        EmployeeService _employeeService;
        public CreateEmployeeHandler(IBaseRepository<Employee> repository, EmployeeService employeeService)
        {
            _repository = repository;
            _employeeService = employeeService;
        }
        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isValidBirthdate = _employeeService.IsValidBirthDate(request.Request.BirthDate);
            if(!isValidBirthdate)
            {
                return new CreateEmployeeResponse() { Status = StatusResponse.Invalid, Errors = [EntityErrors.InvalidInputParam(nameof(request.Request.BirthDate))] };
            }

            var isUnique = await _employeeService.IsIdUnique(request.Request.EmployeeId);
            if (!isUnique)
            {
                return new CreateEmployeeResponse() { Status = StatusResponse.Conflict, Errors = [ EntityErrors.Duplicated ] };
            }

            var addedEmployee = await _repository.AddAsync(new Employee() { EmployeeId = request.Request.EmployeeId, FullName = request.Request.FullName, BirthDate = request.Request.BirthDate });

            return new CreateEmployeeResponse() { Status = StatusResponse.Ok, Employee = addedEmployee };
        }
    }
}
