using Domain.Entities;
using Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IUsersRepo
    {
        public Task<ResultModel> Insert(UsersEntity entity);
        public Task<ResultModel> Update(UsersEntity entity);
        public Task<ResultModel> Delete(UsersEntity entity);
        public Task<List<UsersEntity>> FindByID(int ID);
        public Task<List<UsersEntity>> FindAll();
    }
}
