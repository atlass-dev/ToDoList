using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities;

/// <summary>
/// Assignment entity.
/// </summary>
public class Assignment
{
	/// <summary>
	/// Assignment's id.
	/// </summary>
	[Key]
	public int Id { get; set; }

	/// <summary>
	/// Assignment's title.
	/// </summary>
	[Required]
	required public string Title { get; set; }

	/// <summary>
	/// Assignment's description.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// The date until assignment must be completed.
	/// </summary>
	public DateTime CompleteUntil { get; set; }

	/// <summary>
	/// The date when assignment has been completed.
	/// </summary>
	public DateTime? CompletedAt { get; set; }
}
