using AutoMapper;
using ToDoList.Domain.Entities;
using ToDoList.UseCases.Common.Dtos;

namespace ToDoList.UseCases.Assignments;

/// <summary>
/// Mapping profile for cases related to assignments.
/// </summary>
public class AssignmentMappingProfile : Profile
{
	/// <summary>
	/// Constructor.
	/// </summary>
	public AssignmentMappingProfile()
	{
		CreateMap<Assignment, AssignmentDto>();
	}
}
