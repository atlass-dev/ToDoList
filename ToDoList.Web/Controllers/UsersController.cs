using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

	/// <summary>
	/// Constructor.
	/// </summary>
	public UsersController(IMediator mediator, IMapper mapper)
	{
		this.mediator = mediator;
		this.mapper = mapper;
	}

	/// <summary>
	/// Shows page of specific user.
	/// </summary>
	/// <param name="userId">User's id.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A page of user.</returns>
	[HttpGet("{userId}")]
	public async Task<IActionResult> Details(int userId, CancellationToken cancellationToken)
	
	{
		var userDto = await mediator.Send(new GetUserByIdQuery(userId), cancellationToken);

		var user = mapper.Map<UserViewModel>(userDto);

		return View(user);
	}

	/// <summary>
	/// Gets user registration page.
	/// </summary>
	[HttpGet("register")]
	public IActionResult Register()
	{
		return View();
	}

	/// <summary>
	/// Gets user login page.
	/// </summary>
	[HttpGet("login")]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(UserLoginViewModel user, CancellationToken cancellationToken)
	{
		return View();
	}

	/// <summary>
	/// Registers a user.
	/// </summary>
	/// <param name="user">User data.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Redirects to user page.</returns>
	[HttpPost("register")]
	public async Task<IActionResult> Register(UserRegisterViewModel user, CancellationToken cancellationToken)
	{
		var userId = await mediator.Send(new CreateUserCommand(user.Firstname, user.Lastname, user.Password, user.Email, user.Birthdate), cancellationToken);

		return RedirectToAction(nameof(Index), new { userId = userId });
	}
}
