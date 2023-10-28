using BrewUp.Sales.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Sales.Facade.Validators;

public class SalesOrderValidator : AbstractValidator<SalesOrderModel>
{
    public SalesOrderValidator()
    {
        RuleFor(v => v.PubId).NotEqual(Guid.Empty);
        RuleFor(v => v.OrderDate).GreaterThan(DateTime.MinValue);

        RuleForEach(v => v.Rows).SetValidator(new SalesOrderLineValidator());
    }
}