using Domain.Entities;
using Domain.Specification.Common;
using Domain.Specification.Enum;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Repository;
using Presentation.Data;
using Presentation.Validation;


namespace Presentation.View
{
    public class UsersView : IUsersData
    {
        private readonly IUsersRepo repo;

        public UsersView(IUsersRepo _repo)
        {
            repo = _repo;
        }

        public async Task<ResultModel> Insert(UsersEntity entity)
        {
            ResultModel resultModel = new ResultModel();
            UsersValidation validtor = new UsersValidation();
            ValidationResult validationResult = validtor.Validate(entity);
            if (validationResult.IsValid)
            {
                resultModel = await repo.Insert(entity);
            }
            else
            {
                resultModel.Status = (int)ResponseStatusCode.Error;
                foreach (var item in validationResult.Errors)
                {
                    resultModel.Message += item.ErrorMessage + Environment.NewLine;
                }
            }

            return resultModel;
        }

        public async Task<ResultModel> Update(UsersEntity entity)
        {
            ResultModel resultModel = new ResultModel();
            UsersValidation validtor = new UsersValidation();
            ValidationResult validationResult = validtor.Validate(entity);
            if (validationResult.IsValid)
            {
                resultModel = await repo.Update(entity);
            }
            else
            {
                resultModel.Status = (int)ResponseStatusCode.Error;
                foreach (var item in validationResult.Errors)
                {
                    resultModel.Message += item.ErrorMessage + Environment.NewLine;
                }
            }

            return resultModel;
        }


        public async Task<ResultModel> Delete(UsersEntity entity)
        {
            return await repo.Delete(entity);
        }

        public async Task<List<UsersEntity>> FindByID(int ID)
        {
            return await repo.FindByID(ID);
        }

        public async Task<List<UsersEntity>> FindAll()
        {
            return await repo.FindAll();
        }
    }
}
