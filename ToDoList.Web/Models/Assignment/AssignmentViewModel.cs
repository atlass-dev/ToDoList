﻿using System.ComponentModel.DataAnnotations;
using ToDoList.Web.Models.User;

namespace ToDoList.Web.Models.Assignment;

/// <summary>
/// View model of Assignment.
/// </summary>
public record AssignmentViewModel
{
	/// <summary>
	/// Assignment's id.
	/// </summary>
	public int Id { get; init; }

	/// <summary>
	/// Assignment's title.
	/// </summary>
	[Required]
	[MaxLength(50)]
	required public string Title { get; init; }

	/// <summary>
	/// Assignment's description.
	/// </summary>
	[MaxLength(500)]
	public string? Description { get; init; }

	/// <summary>
	/// The date until assignment must be completed.
	/// </summary>
	[Display(Name = "Complete until")]
	public DateTime? CompleteUntil { get; init; }

	/// <summary>
	/// The date when assignment has been completed.
	/// </summary>
	public DateTime? CompletedAt { get; init; }

	/// <summary>
	/// Id of user who created this assignment.
	/// </summary>
	public int UserId { get; init; }
}
