using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Orders.Commands.Create;

public record CreateOrdersCommand : IRequest<Order>
{
    public String OrderedBy { get; set; } = String.Empty;
    public String driverId { get; set; }
    public String Start { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;
    public Boolean status { get; set; } = false;
}

public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, Order>
{
    private readonly IApplicationDbContext _context;

    public CreateOrdersCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
    {
        var entity = new Order
        {
            OrderedBy = request.OrderedBy,
            driverId = request.driverId,
            Start = request.Start,
            Destination = request.Destination,
            status = request.status
        };

        // entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Orders.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
