using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Application abstraction for unit of work.
/// </summary>
public interface IAppDbContext : IDbContextWithSets
{
	/// <summary>
	/// Users.
	/// </summary>
	DbSet<User> Users { get; }

	/// <summary>
	/// Assignments.
	/// </summary>
	DbSet<Assignment> Assignments { get; }
}
