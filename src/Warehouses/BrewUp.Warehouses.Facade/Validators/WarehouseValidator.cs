using BrewUp.Warehouses.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Warehouses.Facade.Validators;

public class WarehouseValidator : AbstractValidator<WarehouseJson>
{
    public WarehouseValidator()
    {
        RuleFor(v => v.WarehouseId).NotEqual(Guid.Empty);
        RuleFor(v => v.WarehouseName).NotEmpty();
    }
}