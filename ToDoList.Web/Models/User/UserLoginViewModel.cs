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
	[DataType(DataType.EmailAddress)]
	required public string Email { get; init; }

	/// <summary>
	/// User's password.
	/// </summary>
	[Required]
	[DataType(DataType.Password)]
	required public string Password { get; init; }
}
