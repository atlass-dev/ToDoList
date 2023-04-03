using MediatR;

namespace ToDoList.UseCases.Users.AuthenticateUser;

/// <summary>
/// Authenticates user by email and password.
/// </summary>
/// <param name="Email">User's email.</param>
/// <param name="Password">User's password.</param>
public record AuthenticateUserCommand(string Email, string Password) : IRequest<int>;
