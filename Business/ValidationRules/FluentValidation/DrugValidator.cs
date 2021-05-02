using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d=>d.TITCKCode).NotEmpty();
            RuleFor(d => d.Name).MinimumLength(5);
            RuleFor(d => d.Price).GreaterThan(0);
        }
    }
}
