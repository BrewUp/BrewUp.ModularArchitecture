﻿using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace BrewUp.Infrastructures.MongoDb.Readmodel;

public class CustomPersister : IPersister
{
	private readonly IMongoDatabase _database;
	private readonly ILogger _logger;
	
	public string DatabaseName { get; private set;  }

	public CustomPersister(IMongoClient mongoClient, ILoggerFactory loggerFactory)
	{
		_database = mongoClient.GetDatabase(DatabaseName);
		_logger = loggerFactory.CreateLogger(GetType());
	}
	
	public  void SetDatabaseName(string databaseName)
	{
		DatabaseName = databaseName;
	}

	public async Task<T> GetByIdAsync<T>(string id, CancellationToken cancellationToken) where T : EntityBase
	{
		cancellationToken.ThrowIfCancellationRequested();

		var type = typeof(T).Name;
		try
		{
			var collection = _database.GetCollection<T>(typeof(T).Name);
			var filter = Builders<T>.Filter.Eq("_id", id);
			return (await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken) > 0
				? (await collection.FindAsync(filter, cancellationToken: cancellationToken)).First()
				: null)!;
		}
		catch (Exception e)
		{
			_logger.LogError("Insert: Error saving DTO: {Type}, Message: {EMessage}, StackTrace: {EStackTrace}", type,
				e.Message, e.StackTrace);
			throw;
		}
	}

	public async Task InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase
	{
		cancellationToken.ThrowIfCancellationRequested();

		var type = typeof(T).Name;
		try
		{
			var collection = _database.GetCollection<T>(type);
			await collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
		}
		catch (Exception e)
		{
			_logger.LogError($"Insert: Error saving DTO: {type}, Message: {e.Message}, StackTrace: {e.StackTrace}");
			throw;
		}
	}

	public async Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase
	{
		cancellationToken.ThrowIfCancellationRequested();

		var type = typeof(T).Name;
		try
		{
			var collection = _database.GetCollection<T>(type);
			await collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, cancellationToken: cancellationToken);
		}
		catch (Exception e)
		{
			_logger.LogError($"Update: Error saving DTO: {type}, Message: {e.Message}, StackTrace: {e.StackTrace}");
			throw;
		}
	}

	public async Task DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase
	{
		cancellationToken.ThrowIfCancellationRequested();

		var type = typeof(T).Name;
		try
		{
			var collection = _database.GetCollection<T>(typeof(T).Name);
			var filter = Builders<T>.Filter.Eq("_id", entity.Id);
			await collection.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);
		}
		catch (Exception e)
		{
			_logger.LogError($"Delete: Error saving DTO: {type}, Message: {e.Message}, StackTrace: {e.StackTrace}");
			throw;
		}
	}
}