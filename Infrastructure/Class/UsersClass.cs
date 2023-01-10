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
    public class UsersClass : IUsersRepo
    {

        private readonly IUsers application;

        public UsersClass(IUsers _application)
        {
            application = _application;
        }

        public async Task<ResultModel> Insert(UsersEntity entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return await application.Insert(entity, "Manage_Users", dynamicParameters);
        }

        public async Task<ResultModel> Update(UsersEntity entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return await application.Update(entity, "Manage_Users", dynamicParameters);
        }

        public async Task<ResultModel> Delete(UsersEntity entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return await application.Delete(entity, "Manage_Users", dynamicParameters);
        }

        public async Task<List<UsersEntity>> FindByID(int ID)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return await application.FindByID(ID, "Manage_Users");
        }

        public async Task<List<UsersEntity>> FindAll()
        {
            return await application.FindAll("Manage_Users");
        }
    }
}
