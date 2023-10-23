using BrewUp.Purchases.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Purchases.Facade.Validators;

public class PurchasesOrderValidator : AbstractValidator<PurchasesOrderJson>
{
    public PurchasesOrderValidator()
    {
        RuleFor(v => v.SupplierId).NotEqual(Guid.Empty);
        RuleFor(v => v.Date).GreaterThan(DateTime.MinValue);

        RuleForEach(v => v.Lines).SetValidator(new PurchasesOrderLineValidator());
    }
}