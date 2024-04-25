using HRSolutions.UseCases.Models;
using HRSolutions.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSolutions.Application.Models;

namespace HRSolutions.UseCases.Models
{
    public record DeleteEmployeeCommand(DeleteEmployeeRequest Request) : IRequest<DeleteEmployeeResponse>;
        
}
