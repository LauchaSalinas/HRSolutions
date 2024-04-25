using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.Application.Models
{
    public abstract class BaseRequest
    {
        public DateTime Date { get; set; } = DateTime.Now;

        // TODO pending adding audit properties sunch as UserIdentity, Role, UpdateDate, etc once Authentication and Authorization are implemented
    }
}
