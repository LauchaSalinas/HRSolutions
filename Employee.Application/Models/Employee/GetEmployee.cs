using HRSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.Application.Models
{
    public class GetEmployeeRequest : BaseRequest
    {
        public string? NameQuery { get; set; }
    }

    public class GetEmployeeResponse : BaseResponse
    {
        public ICollection<Employee>? Employees { get; set; }
    }
}
