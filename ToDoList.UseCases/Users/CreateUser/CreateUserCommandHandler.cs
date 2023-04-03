using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Abstractions.Interfaces;

namespace ToDoList.UseCases.Users.CreateUser;

/// <summary>
/// Handler for <see cref="CreateUserCommand"/>.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
	private readonly SignInManager<User> signInManager;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="dbContext">Database context.</param>
	public CreateUserCommandHandler(SignInManager<User> signInManager)
	{
		this.signInManager = signInManager;
	}

	/// <inheritdoc/>
	public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var user = CreateUserFromRequest(request);

		var result = await signInManager.UserManager.CreateAsync(user);

		if (result.Succeeded)
		{
			await signInManager.SignInAsync(user, false);
		}

		throw new ArgumentException("Email is already used.");
	}

	private User CreateUserFromRequest(CreateUserCommand request)
	{
		var hasher = new PasswordHasher<IdentityUser>();
		IdentityUser identityUser = new IdentityUser();

		return new User()
		{
		    FirstName = request.Firstname,
			LastName = request.Lastname,
			PasswordHash = hasher.HashPassword(identityUser, request.Password),
			Email = request.Email,
			Birthdate = request.BirthDate,
		};
	} 
}
