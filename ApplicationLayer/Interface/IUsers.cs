using Dapper;
using Domain.Entities;
using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUsers
    {
        public Task<ResultModel> Insert(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter);
        public Task<ResultModel> Update(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter);
        public Task<ResultModel> Delete(UsersEntity entity, string storeProcedure, DynamicParameters dynamicParameter);
        public Task<List<UsersEntity>> FindByID(int ID, string storeProcedure);
        public Task<List<UsersEntity>> FindAll(string storeProcedure);
    }
}
