using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models.User;

/// <summary>
/// User's login view model.
/// </summary>
public record UserLoginViewModel
{
	/// <summary>
	/// User's email.
	/// </summary>
	[Required]
	required public string Email { get; init; }

	/// <summary>
	/// User's password.
	/// </summary>
	[Required]
	required public string Password { get; init; }
}
