using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public abstract class ServiceBase
{
	protected readonly IPersister Persister;
	protected readonly ILogger Logger;

    protected ServiceBase(ILoggerFactory loggerFactory, IPersister persister)
    {
	    Persister = persister;
	    Persister.SetDatabaseName("BrewUp_Warehouses");
	    Logger = loggerFactory.CreateLogger(GetType());
    }
}