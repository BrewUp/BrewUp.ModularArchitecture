using BrewUp.Sales.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Sales.Facade.Validators;

public class SalesOrderValidator : AbstractValidator<SalesOrderJson>
{
    public SalesOrderValidator()
    {
        RuleFor(v => v.CustomerId).NotEqual(Guid.Empty);
        RuleFor(v => v.Date).GreaterThan(DateTime.MinValue);

        RuleForEach(v => v.Lines).SetValidator(new SalesOrderLineValidator());
    }
}