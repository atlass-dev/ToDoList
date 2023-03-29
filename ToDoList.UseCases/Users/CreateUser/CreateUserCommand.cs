using MediatR;

namespace ToDoList.UseCases.Users.CreateUser;

/// <summary>
/// Creates user.
/// </summary>
/// <param name="Firstname">User's firstname.</param>
/// <param name="Lastname">User's lastname.</param>
/// <param name="Password">User's password.</param>
/// <param name="Email">User's email.</param>
/// <param name="BirthDate">User's birthdate.</param>
public record CreateUserCommand(
	string Firstname, 
	string Lastname, 
	string Password, 
	string Email, 
	DateTime? BirthDate) : IRequest<int>;
