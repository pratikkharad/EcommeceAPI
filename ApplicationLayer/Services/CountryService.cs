using Application.Interface;
using Dapper;
using Domain.Entities;
using Domain.Specification.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CountryService : ICountry
    {
        private readonly ILogger<CountryService> logger;
        private readonly IConfiguration configuration;
        public CountryService(ILogger<CountryService> _logger, IConfiguration _configuration)
        {
            logger = _logger;
            configuration = _configuration;     
        }

        public async Task<ResultModel> Insert(CountryEntity entity, string storeProcedure, DynamicParameters dynamicParameter)
        {
            ResultModel resultModel = new ResultModel();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                await sqlConnection.OpenAsync();
                dynamicParameter.Add("CountryName", entity.CountryName);
                dynamicParameter.Add("CountryCode", entity.CountryCode);
            
                //dynamicParameter.Add("CreatedBy", entity.CreatedBy);
                dynamicParameter.Add("OperationType", RepositoryConstants.Insert);
                var data = await sqlConnection.QueryAsync<ResultModel>(storeProcedure, dynamicParameter,
                    commandType: CommandType.StoredProcedure);

                resultModel.Message = data.FirstOrDefault().Message;
                resultModel.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                resultModel.Message = "Failur";
                resultModel.Details = sqlException.Message;
            }
            catch (Exception ex)
            {
                resultModel.Message = "Failur";
                resultModel.Details = ex.Message;
            }
            finally
            {
               
                await sqlConnection.DisposeAsync();
                sqlConnection.Close();
            }

            return resultModel;

        }
    }
}
