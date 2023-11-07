    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
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
            "BrewUp.Purchases.Domain",
            "BrewUp.Purchases.Messages",
            "BrewUp.Purchases.ReadModel",
            "BrewUp.Purchases.SharedKernel",
            "BrewUp.Warehouses.Facade",
            "BrewUp.Warehouses.Domain",
            "BrewUp.Warehouses.Messages",
            "BrewUp.Warehouses.Infrastructures",
            "BrewUp.Warehouses.ReadModel",
            "BrewUp.Warehouses.SharedKernel",
            "BrewUp.Production.Facade",
            "BrewUp.Production.Domain",
            "BrewUp.Production.Messages",
            "BrewUp.Production.Infrastructures",
            "BrewUp.Production.ReadModel",
            "BrewUp.Production.SharedKernel",
            "BrewUp.Purchases.Facade",
            "BrewUp.Purchases.Domain",
            "BrewUp.Purchases.Messages",
            "BrewUp.Purchases.Infrastructures",
            "BrewUp.Purchases.ReadModel",
            "BrewUp.Purchases.SharedKernel"
        };

        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
    
    [Fact]
    // Classes in the module Sales should have namespace starting with BrewUp.Sales
    public void SalesProjects_Should_Having_Namespace_StartingWith_BrewUp_Sales()
    {
        var purchaseModulePath = Path.Combine(SolutionProvider.TryGetSolutionDirectoryInfo().FullName, "Sales");
        var subFolders = Directory.GetDirectories(purchaseModulePath);

        var netVersion = Environment.Version;

        var salesAssemblies = (from folder in subFolders
            let binFolder = Path.Join(folder, "bin", "Debug", $"net{netVersion.Major}.{netVersion.Minor}")
            let files = Directory.GetFiles(binFolder)
            let folderArray = folder.Split(Path.DirectorySeparatorChar)
            select files.FirstOrDefault(f => f.EndsWith($"{folderArray[folderArray!.Length - 1]}.dll"))
            into assemblyFilename
            where !assemblyFilename!.Contains("Test")
            select Assembly.LoadFile(assemblyFilename!)).ToList();

        var salesTypes = Types.InAssemblies(salesAssemblies);
        var salesResult = salesTypes
            .Should()
            .ResideInNamespaceStartingWith("BrewUp.Sales")
            .GetResult();

        Assert.True(salesResult.IsSuccessful);
    }

    
    private static class SolutionProvider
    {
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string? currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}