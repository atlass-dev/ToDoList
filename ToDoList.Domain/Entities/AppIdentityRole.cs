using Microsoft.AspNetCore.Identity;

namespace ToDoList.Domain.Entities;

/// <summary>
/// Custom application identity role.
/// </summary>
public class AppIdentityRole : IdentityRole<int>
{
}
