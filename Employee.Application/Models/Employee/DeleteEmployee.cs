﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.Application.Models
{
    public class DeleteEmployeeRequest : BaseRequest
    {
        public required string EmployeeId { get; set; }
    }

    public class DeleteEmployeeResponse : BaseResponse
    {

    }
}
