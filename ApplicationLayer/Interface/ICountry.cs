using Dapper;
using Domain.Entities;
using Domain.Specification.Common;


namespace Application.Interface
{
    public interface ICountry
    {
        public Task<ResultModel> Insert(CountryEntity entity, string storeProcedure, DynamicParameters dynamicParameter);
    
    }
}
