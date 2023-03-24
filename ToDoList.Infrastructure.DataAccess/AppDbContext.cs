using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Abstractions.Interfaces;

namespace ToDoList.Infrastructure.DataAccess;

/// <summary>
/// Application database context.
/// </summary>
public class AppDbContext : IdentityDbContext<User, AppIdentityRole, int>, IAppDbContext
{
	/// <inheritdoc/>
	public DbSet<Assignment> Assignments { get; set; }

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="options">The options to configure database context.</param>
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	/// <inheritdoc/>
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
	}
}
