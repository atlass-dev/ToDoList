using MediatR;

namespace ToDoList.UseCases.Assignments.CreateAssignment;

/// <summary>
/// Creates an assignment.
/// </summary>
public record CreateAssignmentCommand: IRequest
{
	/// <summary>
	/// Assignment's title.
	/// </summary>
	required public string Title { get; init; }

	/// <summary>
	/// Assignment's description.
	/// </summary>
	public string? Description { get; init; }

	/// <summary>
	/// The date until assignment must be completed.
	/// </summary>
	public DateTime? CompleteUntil { get; init; }

	/// <summary>
	/// User id.
	/// </summary>
	required public int UserId { get; init; }
}
