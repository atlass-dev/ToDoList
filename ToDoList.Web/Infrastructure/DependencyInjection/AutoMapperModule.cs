using ToDoList.UseCases.Utils;

namespace ToDoList.Web.Infrastructure.DependencyInjection;

public static class AutoMapperModule
{
    /// <summary>
    /// Registers dependencies related to AutoMapper.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(UserMappingProfile).Assembly);
    }
}
