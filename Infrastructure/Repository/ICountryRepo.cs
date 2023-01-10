using Domain.Entities;
using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface ICountryRepo
    {
        public Task<ResultModel> Insert(CountryEntity entity);
    }
}
