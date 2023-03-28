using ToDoList.Infrastructure.Abstractions.Interfaces;
using ToDoList.Infrastructure.DataAccess;

namespace ToDoList.Web.Infrastructure.DependencyInjection;

/// <summary>
/// System dependencies.
/// </summary>
internal static class SystemModule
{
	/// <summary>
	/// Registers dependencies.
	/// </summary>
	/// <param name="services">Services.</param>
	public static void Register(IServiceCollection services)
	{
		services.AddScoped<IAppDbContext, AppDbContext>();
	}
}
