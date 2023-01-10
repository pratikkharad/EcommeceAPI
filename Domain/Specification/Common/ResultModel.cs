using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specification.Common
{
    public  class ResultModel
    {
        public dynamic Result { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string CachingStatus { set; get; }
        public int ItemCount { set; get; }
        public int TotalPages { get; set; }
    }
}
