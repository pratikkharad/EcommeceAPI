using Application.Interface;
using Dapper;
using Domain.Entities;
using Domain.Specification.Common;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Class
{
    public class CountryClass : ICountryRepo
    {
        private readonly ICountry application;

        public CountryClass(ICountry _application)
        {
            application = _application;
        }

        public async Task<ResultModel> Insert(CountryEntity entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return await application.Insert(entity, "ManageCountry", dynamicParameters);
        }
    }
}
