using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Orders.Commands.Update;

public record UpdateOrdersCommand : IRequest
{
    public int Id { get; set; }
    public String OrderedBy { get; set; } = String.Empty;
    public String driverId { get; set; }
    public String Start { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;
    public Boolean status { get; set; } = false;
}

public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrdersCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrdersCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOrdersCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Orders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Orders), request.Id);
        }

        entity.OrderedBy = request.OrderedBy;
        entity.driverId = request.driverId;
        entity.Start = request.Start;
        entity.Destination = request.Destination;
        entity.status = request.status;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
