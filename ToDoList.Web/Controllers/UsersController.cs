using AutoMapper;
using MediatR;
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
	public async Task<IActionResult> Login(UserLoginViewModel model, CancellationToken cancellationToken)
	{
		var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

		if (result.Succeeded)
		{
			var user = await signInManager.UserManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				throw new ArgumentNullException();
			}

			var principal = await signInManager.CreateUserPrincipalAsync(user);
		}

		return RedirectToAction(nameof(Login));
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
		//var userId = await mediator.Send(new CreateUserCommand(user.Firstname, user.Lastname, user.Password, user.Email, user.Birthdate), cancellationToken);

		var user = new User()
		{
			UserName = model.Email,
			FirstName = model.Firstname,
			LastName = model.Lastname,
			Email = model.Email,
			Birthdate = model.Birthdate
		};

		var result = await signInManager.UserManager.CreateAsync(user, model.Password);

		if (result.Succeeded)
		{
			await signInManager.PasswordSignInAsync(user.Email, model.Password, false, false);
			return RedirectToAction(nameof(Details), new { userId = user.Id });
		}

		return View(model);
	}
}
