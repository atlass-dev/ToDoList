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
	private readonly IAppDbContext dbContext;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="dbContext">Database context.</param>
	public CreateUserCommandHandler(IAppDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	/// <inheritdoc/>
	public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var existingProject = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

		if (existingProject == null)
		{
			var user = CreateUserFromRequest(request);

			await dbContext.Users.AddAsync(user, cancellationToken);

			await dbContext.SaveChangesAsync(cancellationToken);

			return user.Id;
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
