using AutoMapper;
using ToDoList.UseCases.Users.Common.Dtos;
using ToDoList.Web.Models.Assignment;
using ToDoList.Web.Models.User;

namespace ToDoList.Web.Infrastructure;

/// <summary>
/// Web application mapping profile.
/// </summary>
public class WebMappingProfile : Profile
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public WebMappingProfile()
	{
		CreateMap<UserDto, UserViewModel>()
			.ForMember(u => u.Fullname, opt => opt.MapFrom(src => $"{src.FirstName} {src.Lastname}"));
		CreateMap<AssignmentDto, AssignmentViewModel>();
	}
}
