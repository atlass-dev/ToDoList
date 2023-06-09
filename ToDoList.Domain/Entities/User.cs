﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities;

/// <summary>
/// User entity.
/// </summary>
public class User : IdentityUser<int>
{
	/// <summary>
	/// User's first name.
	/// </summary>
	[MaxLength(50)]
	[Required]
	required public string FirstName { get; set; }

	/// <summary>
	/// User's last name.
	/// </summary>
	[MaxLength(50)]
	[Required]
	required public string LastName { get; set; }

	/// <summary>
	/// User's full name.
	/// </summary>
	public string FullName => $"{FirstName} {LastName}";

	/// <summary>
	/// User's birth date.
	/// </summary>
	public DateTime? Birthdate { get; set; }

	/// <summary>
	/// User's assignment.
	/// </summary>
	public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

	/// <summary>
	/// The date when user has been created.
	/// </summary>
	public DateTime CreatedAt { get; set; }
}
