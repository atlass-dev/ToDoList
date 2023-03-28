using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Abstractions.Interfaces;
using ToDoList.UseCases.Users.Common.Dtos;

namespace ToDoList.UseCases.Users.GetUserById;

/// <summary>
/// Handler for <see cref="GetUserByIdQuery"/>.
/// </summary>
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetUserByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.Include(u => u.Assignments).FirstOrDefaultAsync(u => u.Id == request.Id);

        return mapper.Map<UserDto>(user);
    }
}
