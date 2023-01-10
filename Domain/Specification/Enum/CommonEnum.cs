using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specification.Enum
{
    public enum ResponseStatusCode
    {
        Success = 200,
        Error = 201,
        Datavalidation = 2,
        BusinessError = 3
    }

}
