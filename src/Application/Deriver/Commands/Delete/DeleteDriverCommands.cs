using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Application.Deriver.Commands.Delete;
public record DeleteDriverCommands(int Id) : IRequest;

public class DeleteDriverCommandsHandler : IRequestHandler<DeleteDriverCommands>
{
    private readonly IApplicationDbContext _context;

    public DeleteDriverCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteDriverCommands request, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.Id);
        }

        _context.Drivers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
