using FluentValidation;
using Health.Web.Models;

namespace Health.Web.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(0);
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
