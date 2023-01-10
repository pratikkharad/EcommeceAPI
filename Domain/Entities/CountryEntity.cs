using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CountryEntity
    {
        [Required]
        public string? CountryName { get; set; }
        public int? CountryCode { get; set; }
    //    public Boolean? IsActive { get; set; }
    }
}
