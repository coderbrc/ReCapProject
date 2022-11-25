using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(b => b.CarName).NotEmpty();
            RuleFor(b => b.BrandId).NotEmpty();
        }
    }
}
