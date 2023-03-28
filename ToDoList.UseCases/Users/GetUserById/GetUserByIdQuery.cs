using MediatR;
using ToDoList.UseCases.Users.Common.Dtos;

namespace ToDoList.UseCases.Users.GetUserById;

/// <summary>
/// Gets information about user by id.
/// </summary>
/// <param name="Id">Id of user to get data about.</param>
public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
