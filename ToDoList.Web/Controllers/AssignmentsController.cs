using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.UseCases.Assignments.CreateAssignment;
using ToDoList.Web.Models.Assignment;

namespace ToDoList.Web.Controllers;

/// <summary>
/// Contains logic related to assignments.
/// </summary>
[Route("[controller]")]
public class AssignmentsController : Controller
{
	private readonly IMediator mediator;

	/// <summary>
	/// Constructor.
	/// </summary>
	public AssignmentsController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	/// <summary>
	/// Gets a page for creation of new assignment.
	/// </summary>
	[HttpGet("create/{userId}")]
	public IActionResult Create(int userId)
	{
		return View();
	}

	/// <summary>
	/// Creates a new assignment.
	/// </summary>
	/// <param name="model">Creation command.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A page of user.</returns>
	[HttpPost("create/{userId}")]
	public async Task<IActionResult> Create(AssignmentViewModel model, CancellationToken cancellationToken)
	{
		var command = new CreateAssignmentCommand()
		{
			Title = model.Title,
			Description = model.Description,
			CompleteUntil = model.CompleteUntil,
			UserId = model.UserId
		};

		await mediator.Send(command, cancellationToken);

		return RedirectToAction("Details", "Users", new { userId = model.UserId });
	}
}
