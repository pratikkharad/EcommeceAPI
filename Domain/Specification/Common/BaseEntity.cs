using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specification.Common
{
   
    [Serializable]
    public abstract class BaseEntity
    {
        public Int32 ID { set; get; } = 0;
        public Int32 CreatedBy { set; get; }
        public Int32 UpdatedBy { set; get; }
        public string? Message { set; get; } = String.Empty;
        public DateTime? CreatedOn { set; get; } = DateTime.Now;
        public DateTime? UpdatedOn { set; get; }
        public Int64 StatusID { get; set; }
        public string? Details { get; set; }
    }
}

