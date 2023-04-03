using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Entities;
using ToDoList.UseCases.Users.CreateUser;
using ToDoList.UseCases.Users.GetUserById;
using ToDoList.Web.Models.User;

namespace ToDoList.Web.Controllers;

/// <summary>
/// Contains logic related to users.
/// </summary>
[Route("[controller]")]
public class UsersController : Controller
{
	private readonly IMediator mediator;
	private readonly IMapper mapper;
	private readonly SignInManager<User> signInManager;

	/// <summary>
	/// Constructor.
	/// </summary>
	public UsersController(IMediator mediator, IMapper mapper, SignInManager<User> signInManager)
	{
		this.mediator = mediator;
		this.mapper = mapper;
		this.signInManager = signInManager;
	}

	/// <summary>
	/// Shows page of specific user.
	/// </summary>
	/// <param name="userId">User's id.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A page of user.</returns>
	[HttpGet("{userId}")]
	[Authorize]
	public async Task<IActionResult> Details(int userId, CancellationToken cancellationToken)
	{
		var userDto = await mediator.Send(new GetUserByIdQuery(userId), cancellationToken);

		var user = mapper.Map<UserViewModel>(userDto);

		return View(user);
	}
}
