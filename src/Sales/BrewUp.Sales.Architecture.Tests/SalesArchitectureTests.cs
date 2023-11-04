﻿using System.Diagnostics.CodeAnalysis;
using BrewUp.Sales.Facade;
using NetArchTest.Rules;
using Xunit;

namespace BrewUp.Sales.Architecture.Tests;

[ExcludeFromCodeCoverage]
public class SalesArchitectureTests
{
    [Fact]
    public void Should_SalesArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(ISalesFacade).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "BrewUp.Sagas",
            "BrewUp.Purchases.Facade",
            "BrewUp.Purchases.ReadModel",
            "BrewUp.Purchases.SharedKernel",
            "BrewUp.Warehouses.Facade",
            "BrewUp.Warehouses.ReadModel",
            "BrewUp.Warehouses.SharedKernel",
            "BrewUp.Production.Facade",
            "BrewUp.Production.ReadModel",
            "BrewUp.Production.SharedKernel"
        };

        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
}