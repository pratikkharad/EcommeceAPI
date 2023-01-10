using Domain.Entities;
using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Data
{
    public interface ICountryData
    {
        public Task<ResultModel> Insert(CountryEntity entity);
    }
}
