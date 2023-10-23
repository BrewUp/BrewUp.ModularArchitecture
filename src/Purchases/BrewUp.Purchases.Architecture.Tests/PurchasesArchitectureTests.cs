using System.Diagnostics.CodeAnalysis;
using BrewUp.Purchases.Facade;
using NetArchTest.Rules;

namespace BrewUp.Purchases.Architecture.Tests;

[ExcludeFromCodeCoverage]
public class PurchasesArchitectureTests
{
    [Fact]
    public void Should_PurchasesArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(IPurchasesFacade).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "BrewUp.Sales.Domain",
            "BrewUp.Sales.Messages",
            "BrewUp.Sales.ReadModel",
            "BrewUp.Sales.SharedKernel",
            "BrewUp.Warehouses.Facade",
            "BrewUp.Warehouses.ReadModel"
        };

        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
}