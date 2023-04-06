using MediatR;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Abstractions.Interfaces;

namespace ToDoList.UseCases.Assignments.CreateAssignment;

/// <summary>
/// Handler for <see cref="CreateAssignmentCommand"/>.
/// </summary>
public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand>
{
	private readonly IAppDbContext dbContext;

	/// <summary>
	/// Constructor.
	/// </summary>
	public CreateAssignmentCommandHandler(IAppDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	/// <inheritdoc/>
	public async Task Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
	{
		var assignment = new Assignment() 
		{ 
			Title = request.Title,
			Description = request.Description,
			CompleteUntil = request.CompleteUntil,
			UserId = request.UserId
		};

		await dbContext.Assignments.AddAsync(assignment, cancellationToken);
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}
