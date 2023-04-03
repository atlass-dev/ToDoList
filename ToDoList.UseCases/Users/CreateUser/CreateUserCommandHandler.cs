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
		var user = new User()
		{
			UserName = request.Email,
			FirstName = request.Firstname,
			LastName = request.Lastname,
			Email = request.Email,
			Birthdate = request.BirthDate
		};

		var result = await signInManager.UserManager.CreateAsync(user, request.Password);

		if (result.Succeeded)
		{
			await signInManager.PasswordSignInAsync(user.Email, request.Password, isPersistent: true, lockoutOnFailure: false);

			return user.Id;
		}

		throw new ArgumentException("User with this email already exists.");
	}
}
