using Microsoft.EntityFrameworkCore;

namespace ToDoList.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Database context which retrieves collection by provided type.
/// </summary>
public interface IDbContextWithSets
{
	/// <summary>
	/// Get set of entities by type.
	/// </summary>
	/// <typeparam name="TEntity">Entity type.</typeparam>
	/// <returns>Set of entities.</returns>
	DbSet<TEntity> Set<TEntity>() where TEntity : class;

	/// <summary>
	/// Saves changes.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Amount of changes.</returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
