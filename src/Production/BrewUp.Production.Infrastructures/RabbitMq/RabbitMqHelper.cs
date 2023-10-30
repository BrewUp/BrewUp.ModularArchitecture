using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Production.Infrastructures.RabbitMq.Commands;
using BrewUp.Production.Infrastructures.RabbitMq.Events;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Factories;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Production.Infrastructures.RabbitMq;

public static class RabbitMqHelper
{
	public static IServiceCollection AddRabbitMqForProductionModule(this IServiceCollection services,
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
			new BeersForSaleCommittedConsumer(serviceProvider.GetRequiredService<IServiceBus>(), connectionFactory, loggerFactory),
			
			new CreateProductionOrderConsumer(repository, connectionFactory, loggerFactory),
			new ProductionOrderCreatedConsumer(serviceProvider.GetRequiredService<IProductionOrderService>(), connectionFactory, loggerFactory)
		});
		services.AddMufloneRabbitMQConsumers(consumers);

		return services;
	}
}