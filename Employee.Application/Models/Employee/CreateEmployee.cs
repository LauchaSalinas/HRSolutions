using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.Application.Models
{
    public class CreateEmployeeRequest
    {
        public required string EmployeeId { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string FullName { get; set; }
    }

    public class CreateEmployeeResponse : BaseResponse { }
}
