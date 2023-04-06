namespace ToDoList.Infrastructure.Exceptions;

/// <summary>
/// Exception for cases when something wasn't found.
/// </summary>
public class NotFoundException : Exception
{
	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="message">Message to provide with exception.</param>
	public NotFoundException(string? message) : base(message)
	{
	}
}
