using ToDoList.Web.Models.Assignment;

namespace ToDoList.Web.Models.User;

/// <summary>
/// View model of user.
/// </summary>
public record UserViewModel
{
	/// <summary>
	/// User's id.
	/// </summary>
	public int Id { get; init; }

	/// <summary>
	/// User's fullname.
	/// </summary>
	required public string Fullname { get; init; }

	/// <summary>
	/// User's birthdate.
	/// </summary>
	public DateTime? Birthdate { get; init; }

	/// <summary>
	/// User's assignments.
	/// </summary>
	public ICollection<AssignmentViewModel> Assignments { get; init; } = new List<AssignmentViewModel>();
}
