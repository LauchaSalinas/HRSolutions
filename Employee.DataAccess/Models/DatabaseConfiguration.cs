using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSolutions.DataAccess.Models
{
    public class DatabaseConfiguration
    {
        public bool UseInMemoryDatabase { get; set; }

        public string? ConnectionString { get; set; }
    }

}
