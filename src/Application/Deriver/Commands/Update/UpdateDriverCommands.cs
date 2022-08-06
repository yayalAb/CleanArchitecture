using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Deriver.Commands.Update;

public record UpdateDriverCommands : IRequest
{
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String Email { get; set; } = String.Empty;
    public String Phone { get; set; } = String.Empty;
    public int Age { get; set; }
}

public class UpdateDriverCommandsHandler : IRequestHandler<UpdateDriverCommands>
{
    private readonly IApplicationDbContext _context;

    public UpdateDriverCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDriverCommands request, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.Id);
        }

            entity.Name = request.Name,
            entity.Email = request.Email,
            entity.Phone = request.Phone,
            entity.Age = request.Age,

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
