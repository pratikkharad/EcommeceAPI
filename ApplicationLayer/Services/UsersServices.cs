using Dapper;
using Domain.Entities;
using Domain.Specification.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;

namespace Application.Services
{
    public class UsersServices : IUsers
    {
        private readonly ILogger<UsersServices> logger;
        private readonly IConfiguration configuration;
        public UsersServices(ILogger<UsersServices> _logger, IConfiguration _configuration)
        {
            logger = _logger;
            configuration = _configuration;
        }

        #region Insert
        public async Task<ResultModel> Insert(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter)
        {
            ResultModel resultModel = new ResultModel();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                await sqlConnection.OpenAsync();
                dynamicParameter.Add("UserName", entity.UserName);
                dynamicParameter.Add("Password", entity.Password);
                dynamicParameter.Add("FirstName", entity.FirstName);
                dynamicParameter.Add("LastName", entity.LastName);
                dynamicParameter.Add("PhoneNumber", entity.PhoneNumber);
                dynamicParameter.Add("AlternativeEmail", entity.AlternativeEmail);
                dynamicParameter.Add("Address", entity.Address);
                dynamicParameter.Add("LandMark", entity.LandMark);
                dynamicParameter.Add("City", entity.City);
                dynamicParameter.Add("Pincode", entity.Pincode);
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
        #endregion

        // Pratik 26-sep-2022
        #region Update  
        public async Task<ResultModel> Update(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter)
        {
            ResultModel resultModel = new ResultModel();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                await sqlConnection.OpenAsync();
                dynamicParameter.Add("@ID", entity.ID);
                dynamicParameter.Add("UserName", entity.UserName);
                dynamicParameter.Add("Password", entity.Password);
                dynamicParameter.Add("FirstName", entity.FirstName);
                dynamicParameter.Add("LastName", entity.LastName);
                dynamicParameter.Add("PhoneNumber", entity.PhoneNumber);
                dynamicParameter.Add("AlternativeEmail", entity.AlternativeEmail);
                dynamicParameter.Add("Address", entity.Address);
                dynamicParameter.Add("LandMark", entity.LandMark);
                dynamicParameter.Add("City", entity.City);
                dynamicParameter.Add("Pincode", entity.Pincode);
                dynamicParameter.Add("@OperationType", RepositoryConstants.Update);

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
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();
            }

            return resultModel;
        }
        #endregion

        // Pratik 27-sep-2022
        #region Delete

        public async Task<ResultModel> Delete(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter)
        {
            ResultModel resultModel = new ResultModel();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            try
            {
                await sqlConnection.OpenAsync();
                dynamicParameter.Add("@ID", entity.ID);
                dynamicParameter.Add("@OperationType", RepositoryConstants.Delete);

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
                sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();

            }

            return resultModel;

        }

        #endregion

        // Pratik 27-sep-2022
        #region FindByID

        public async Task<List<UsersEntity>> FindByID(int ID, string storeProcedure)
        {

            UsersEntity country = new UsersEntity();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                await sqlConnection.OpenAsync();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@OperationType", RepositoryConstants.FindByID);

                var data = await sqlConnection.QueryAsync<UsersEntity>(storeProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();

            }
        }

        public async Task<List<UsersEntity>> FindAll(string storeProcedure)
        {
            UsersEntity country = new UsersEntity();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                await sqlConnection.OpenAsync();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", RepositoryConstants.FindAllActive);

                var data = await sqlConnection.QueryAsync<UsersEntity>(storeProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();

            }

        }

        #endregion
    }
}
