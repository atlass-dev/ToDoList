using ToDoList.UseCases.Users;

namespace ToDoList.Web.Infrastructure.DependencyInjection;

/// <summary>
/// AutoMapper dependencies.
/// </summary>
public static class AutoMapperModule
{
    /// <summary>
    /// Registers dependencies related to AutoMapper.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(UserMappingProfile).Assembly,
            typeof(WebMappingProfile).Assembly);
    }
}
