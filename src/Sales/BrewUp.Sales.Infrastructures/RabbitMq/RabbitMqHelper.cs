using BrewUp.Infrastructures.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Factories;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Sales.Infrastructures.RabbitMq;

public static class RabbitMqHelper
{
	public static IServiceCollection AddRabbitMq(this IServiceCollection services,
		RabbitMqSettings rabbitMqSettings)
	{
		var serviceProvider = services.BuildServiceProvider();
		var repository = serviceProvider.GetRequiredService<IRepository>();
		var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

		var rabbitMQConfiguration = new RabbitMQConfiguration(rabbitMqSettings.Host, rabbitMqSettings.Username,
			rabbitMqSettings.Password, rabbitMqSettings.ExchangeCommandName, rabbitMqSettings.ExchangeEventName);
		var connectionFactory = new MufloneConnectionFactory(rabbitMQConfiguration, loggerFactory);

		services.AddMufloneTransportRabbitMQ(loggerFactory, rabbitMQConfiguration);

		serviceProvider = services.BuildServiceProvider();
		var consumers = serviceProvider.GetRequiredService<IEnumerable<IConsumer>>();
		consumers = consumers.Concat(new List<IConsumer>
		{
			// new BeersReceivedConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
			// 	connectionFactory,
			// 	loggerFactory),
			//
			// new CreateBeerConsumer(repository!, connectionFactory,
			// 	loggerFactory),
			//
			// new BeerCreatedConsumer(serviceProvider.GetRequiredService<IBeerService>(),
			// 	connectionFactory,
			// 	loggerFactory),
			//
			// new LoadBeerInStockConsumer(repository!, connectionFactory,
			// 	loggerFactory),
			//
			// new BeerLoadedInStockConsumer(serviceProvider.GetRequiredService<IBeerService>(),
			// 	connectionFactory,
			// 	loggerFactory),
			//
			// new BeerCreatedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
			// 	serviceProvider.GetRequiredService<ISagaRepository>(),
			// 	connectionFactory,
			// 	loggerFactory)
		});
		services.AddMufloneRabbitMQConsumers(consumers);

		return services;
	}
}