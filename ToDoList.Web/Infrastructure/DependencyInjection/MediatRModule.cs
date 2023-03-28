using ToDoList.UseCases.Users.GetUserById;

namespace ToDoList.Web.Infrastructure.DependencyInjection;

public class MediatRModule
{
    public static void Register(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));
    }
}
