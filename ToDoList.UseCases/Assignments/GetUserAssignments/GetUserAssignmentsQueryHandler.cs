using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Abstractions.Interfaces;
using ToDoList.Infrastructure.Exceptions;
using ToDoList.UseCases.Common.Dtos;

namespace ToDoList.UseCases.Assignments.GetUserAssignments;

/// <summary>
/// Handler for <see cref="GetUserAssignmentsQuery"/>.
/// </summary>
public class GetUserAssignmentsQueryHandler : IRequestHandler<GetUserAssignmentsQuery, IEnumerable<AssignmentDto>>
{
	private readonly IAppDbContext dbContext;
	private readonly IMapper mapper;

	/// <summary>
	/// Constructor.
	/// </summary>
	public GetUserAssignmentsQueryHandler(IAppDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<AssignmentDto>> Handle(GetUserAssignmentsQuery request, CancellationToken cancellationToken)
	{
		var user = await dbContext.Users.Include(u => u.Assignments).FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException("User doesn't exist.");
		}

		var assignments = mapper.Map<IEnumerable<AssignmentDto>>(user.Assignments);

		return assignments;
	}
}
