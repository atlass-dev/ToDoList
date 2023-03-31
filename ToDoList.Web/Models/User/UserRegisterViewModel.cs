using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models.User;

/// <summary>
/// User's registration view model.
/// </summary>
public record UserRegisterViewModel
{
	/// <inheritdoc cref="User.Firstname"/>
	[Required]
	required public string Firstname { get; init; }

	/// <inheritdoc cref="User.LastName"/>
	[Required]
	required public string Lastname { get; init; }

	/// <summary>
	/// User's password
	/// </summary>
	[Required]
	[MinLength(8)]
	required public string Password { get; init; }

	/// <summary>
	/// User's email.
	/// </summary>
	[Required]
	required public string Email { get; init; }

	/// <inheritdoc cref="User.Birthdate"/>
	public DateTime? Birthdate { get; init; }
}
