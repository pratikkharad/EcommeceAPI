using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class CountryValidation : AbstractValidator<CountryEntity>
    {
        public CountryValidation()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("CountryName is Required");
        }
    }
}
