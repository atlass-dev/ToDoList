namespace ToDoList.UseCases.Users.Common.Dtos;

/// <summary>
/// User entity.
/// </summary>
public record UserDto
{
    /// <summary>
    /// User's id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// User's first name.
    /// </summary>
    required public string FirstName { get; init; }

    /// <summary>
    /// User's last name.
    /// </summary>
    required public string Lastname { get; set; }

    /// <summary>
    /// User's birthdate.
    /// </summary>
    public DateTime? Birthdate { get; init; }

    /// <summary>
    /// List of assignments tied to user.
    /// </summary>
    public ICollection<AssignmentDto> Assignments { get; set; } = new List<AssignmentDto>();
}
