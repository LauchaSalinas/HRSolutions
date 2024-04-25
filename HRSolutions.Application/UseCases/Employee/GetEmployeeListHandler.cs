using MediatR;
using HRSolutions.Domain.Entities;
using HRSolutions.UseCases.Interfaces;
using HRSolutions.Application.Models;
using System.Net.Http.Headers;

namespace HRSolutions.UseCases.Models
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, GetEmployeeResponse>
    {
        private IBaseRepository<Employee> _employeeRepository;
        public GetEmployeeListHandler(IBaseRepository<Employee> repository)
        {
            _employeeRepository = repository;
        }

        public async Task<GetEmployeeResponse> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var searchParam = request.Request.NameQuery ?? string.Empty;
            var employees = await _employeeRepository.GetAllAsync(x => x.FullName.ToLower().Contains(searchParam.ToLower()));
            if (employees.Count == 0)
            {
                return new GetEmployeeResponse { Status = StatusResponse.NotFound };
            }

            return new GetEmployeeResponse { 
                Status = StatusResponse.Ok,  
                Employees = employees
            };
        }
    }
}
