using HRSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.Application.Models
{
    public class CreateEmployeeRequest : BaseRequest
    {
        public required DateOnly BirthDate { get; set; }
        public required string FullName { get; set; }
        public required string EmployeeId { get; set; }
    }

    public class CreateEmployeeResponse : BaseResponse
    {
        public Employee? Employee { get; set; }
    }
}
