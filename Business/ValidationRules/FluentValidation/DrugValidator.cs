using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DrugValidator:AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(d=>d.Name).NotEmpty();
            RuleFor(d => d.Name).MinimumLength(5);
            RuleFor(d=>d.Price).GreaterThan(0);
        }
    }
}
