using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.UseCases.Users.AuthenticateUser;
using ToDoList.UseCases.Users.CreateUser;
using ToDoList.Web.Models.User;

namespace ToDoList.Web.Controllers;

/// <summary>
/// Contains logic related to users accounts.
/// </summary>
[Route("[controller]")]
public class AccountController : Controller
{
	private readonly IMediator mediator;

	/// <summary>
	/// Constructor.
	/// </summary>
	public AccountController(IMediator mediator)
	{
		this.mediator = mediator;
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
	public async Task<IActionResult> Login(UserLoginViewModel model, CancellationToken cancellationToken)
	{
		var userId = await mediator.Send(new AuthenticateUserCommand(model.Email, model.Password), cancellationToken);

		return Redirect($"users/{userId}");
	}

	/// <summary>
	/// Registers a user.
	/// </summary>
	/// <param name="user">User data.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Redirects to user page.</returns>
	[HttpPost("register")]
	public async Task<IActionResult> Register(UserRegisterViewModel model, CancellationToken cancellationToken)
	{
		var userId = await mediator.Send(new CreateUserCommand(model.Firstname, model.Lastname, model.Password, model.Email, model.Birthdate), cancellationToken);

		return Redirect($"users/{userId}");
	}
}
