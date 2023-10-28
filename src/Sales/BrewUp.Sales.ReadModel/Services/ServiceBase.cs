﻿using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.Services;

public abstract class ServiceBase
{
    protected readonly IPersister Persister;
    protected readonly ILogger Logger;

    protected ServiceBase(ILoggerFactory loggerFactory, IPersister persister)
    {
        Persister = persister;
        Logger = loggerFactory.CreateLogger(GetType());
    }
}