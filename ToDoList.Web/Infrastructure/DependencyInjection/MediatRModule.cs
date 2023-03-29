using ToDoList.UseCases.Users.GetUserById;

namespace ToDoList.Web.Infrastructure.DependencyInjection;

/// <summary>
/// MediatR dependencies.
/// </summary>
public class MediatRModule
{
    /// <summary>
    /// Registers dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));
    }
}
