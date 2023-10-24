﻿using System.Linq.Expressions;
using BrewUp.Shared.Entities;

namespace BrewUp.Shared.ReadModel
{
	public interface IQueries<T> where T : EntityBase
	{
		Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
		Task<PagedResult<T>> GetByFilterAsync(Expression<Func<T, bool>>? query, int page, int pageSize, CancellationToken cancellationToken);
	}
}
