using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).MinimumLength(10);
            //RuleFor(s => s.Email).NotEmpty();
            //RuleFor(s => s.Email).EmailAddress();
        }
    }
}
