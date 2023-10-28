using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Sales.Infrastructures.RabbitMq.Commands;
using BrewUp.Sales.Infrastructures.RabbitMq.Events;
using BrewUp.Sales.ReadModel.Services;
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

		var rabbitMqConfiguration = new RabbitMQConfiguration(rabbitMqSettings.Host, rabbitMqSettings.Username,
			rabbitMqSettings.Password, rabbitMqSettings.ExchangeCommandName, rabbitMqSettings.ExchangeEventName);
		var connectionFactory = new MufloneConnectionFactory(rabbitMqConfiguration, loggerFactory);

		services.AddMufloneTransportRabbitMQ(loggerFactory, rabbitMqConfiguration);

		serviceProvider = services.BuildServiceProvider();
		var consumers = serviceProvider.GetRequiredService<IEnumerable<IConsumer>>();
		consumers = consumers.Concat(new List<IConsumer>
		{
			new CreateSalesOrderConsumer(repository,
				connectionFactory,
				loggerFactory),
			new SalesOrderCreatedConsumer(serviceProvider.GetRequiredService<ISalesOrderService>(), connectionFactory, loggerFactory),
			
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