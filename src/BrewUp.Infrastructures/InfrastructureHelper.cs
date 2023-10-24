using BrewUp.Infrastructures.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Infrastructures;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		MongoDbSettings mongoDbSettings,
		EventStoreSettings eventStoreSettings)
	{
		services.AddMongoDb(mongoDbSettings);
		services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName));
		services.AddMufloneEventStore(eventStoreSettings.ConnectionString);

		return services;
	}
}