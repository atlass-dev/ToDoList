using MediatR;
using ToDoList.UseCases.Common.Dtos;

namespace ToDoList.UseCases.Assignments.GetUserAssignments;

/// <summary>
/// Gets all assignments of specific user.
/// </summary>
/// <param name="UserId">User's id.</param>
public record GetUserAssignmentsQuery(int UserId) : IRequest<IEnumerable<AssignmentDto>>;
