using HRSolutions.UseCases.Models;
using HRSolutions.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRSolutions.Application.Models;

namespace HRSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IMediator _mediator;
        public EmployeeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetEmployeeResponse> GetByName(string? name)
        {
            return await _mediator.Send(new GetEmployeeListQuery(new() { NameQuery = name}));
        }

        [HttpPost]
        public async Task<CreateEmployeeResponse> Create(CreateEmployeeRequest req)
        {
            return await _mediator.Send(new CreateEmployeeCommand(req));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteEmployeeResponse> Delete(string id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(new() { EmployeeId = id}));
        }
    }
}
