namespace ToDoList.UseCases.Users.Common.Dtos;

/// <summary>
/// Assignment entity.
/// </summary>
public record AssignmentDto
{
    /// <summary>
    /// Assignment's id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Assignment's title.
    /// </summary>
    required public string Title { get; init; }

    /// <summary>
    /// Assignment description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Date until which assignment must be completed.
    /// </summary>
    public DateTime? CompleteUntil { get; init; }

    /// <summary>
    /// Date when assignment has been completed.
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Id of user.
    /// </summary>
	required public int UserId { get; set; }

    /// <summary>
    /// User who created this assignment.
    /// </summary>
    required public UserDto User { get; init; }
}
