using MediatR;
using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Entities;

namespace ToDoList.UseCases.Users.AuthenticateUser;

/// <summary>
/// Handler for <see cref="AuthenticateUserCommand"/>.
/// </summary>
public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, int>
{
	private readonly SignInManager<User> signInManager;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="signInManager"></param>
	public AuthenticateUserCommandHandler(SignInManager<User> signInManager)
	{
		this.signInManager = signInManager;
	}

	/// <inheritdoc/>
	public async Task<int> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
	{
		var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent: true, lockoutOnFailure: false);
		ValidateSignInResult(result);

		var user = await signInManager.UserManager.FindByEmailAsync(request.Email);

		if (user == null)
		{
			throw new ArgumentException("User with this email not found.");
		}

		return user.Id;
	}

	private void ValidateSignInResult(SignInResult signInResult)
	{
		if (!signInResult.Succeeded)
		{
			throw new ArgumentException("Email or password is incorrect.");
		}
	}
}
