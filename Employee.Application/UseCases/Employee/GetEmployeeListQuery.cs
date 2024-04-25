using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSolutions.Application.Models;
using HRSolutions.Domain.Entities;
using MediatR;

namespace HRSolutions.UseCases.Models
{
    //public class ListEmployeeRequest
    //{
    //    public int Take { get; set; } = 50;
    //    public int Skip { get; set; } = 0;
    //    public string? FullName { get; set; } 
    //}

    //public class ListEmployeeResponse : BaseResponse
    //{
    //    public List<Employee> Employees { get; set; }
    //}

    public record GetEmployeeListQuery(GetEmployeeRequest Request) : IRequest<GetEmployeeResponse>;
}
