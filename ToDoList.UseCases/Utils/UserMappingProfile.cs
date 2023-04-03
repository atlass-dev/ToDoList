using AutoMapper;
using ToDoList.Domain.Entities;
using ToDoList.UseCases.Users.Common.Dtos;

namespace ToDoList.UseCases.Utils;

/// <summary>
/// Mapping profile for use cases related to <see cref="User"/>.
/// </summary>
public class UserMappingProfile : Profile
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public UserMappingProfile()
	{
		CreateMap<User, UserDto>();
		CreateMap<Assignment, AssignmentDto>();
	}
}
