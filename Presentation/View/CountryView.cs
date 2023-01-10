using Domain.Entities;
using Domain.Specification.Common;
using Domain.Specification.Enum;
using FluentValidation.Results;
using Infrastructure.Repository;
using Presentation.Data;
using Presentation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.View
{
    public class CountryView : ICountryData
    {
       private readonly ICountryRepo repo;

        public CountryView(ICountryRepo _repo)
        {
            repo = _repo;
        }

        public async Task<ResultModel> Insert(CountryEntity entity)
        {
            ResultModel resultModel = new ResultModel();
            CountryValidation validtor = new CountryValidation();
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
    }
}
