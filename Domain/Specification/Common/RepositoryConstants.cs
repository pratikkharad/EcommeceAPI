using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specification.Common
{
    public static class RepositoryConstants
    {
        public const int Insert = 1;
        public const int Update = 2;
        public const int Delete = 3;
        public const int FindByID = 4;
        public const int FindAllItems = 5;
        public const int FindAllActive = 6;
        public const int UpdateActive = 7;
        public const int IsDelete = 8;
    }
}
