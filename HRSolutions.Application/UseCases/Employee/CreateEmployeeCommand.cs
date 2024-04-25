using HRSolutions.Application.Models;
using HRSolutions.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.UseCases.Models
{
    public record CreateEmployeeCommand(CreateEmployeeRequest Request) : IRequest<CreateEmployeeResponse>;
}
