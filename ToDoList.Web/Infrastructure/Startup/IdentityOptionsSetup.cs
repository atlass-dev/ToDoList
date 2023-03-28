using Microsoft.AspNetCore.Identity;

namespace ToDoList.Web.Infrastructure.Startup;

/// <summary>
/// Identity options setup.
/// </summary>
public class IdentityOptionsSetup
{
	/// <summary>
	/// Setup identity.
	/// </summary>
	/// <param name="options">Options.</param>
	public void Setup(IdentityOptions options)
	{
		options.User.RequireUniqueEmail = true;
		options.Password.RequireNonAlphanumeric = false;
	}
}
