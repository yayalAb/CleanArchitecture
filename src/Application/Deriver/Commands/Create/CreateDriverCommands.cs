using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;
namespace CleanArchitecture.Application.Deriver.Commands.Create;

public record CreateDriverCommands : IRequest<Driver>
{
    public String Name { get; set; } = String.Empty;
    public String Email { get; set; } = String.Empty;
    public String Phone { get; set; } = String.Empty;
    public int Age { get; set; }
}

public class CreateDriverCommandsHandler : IRequestHandler<CreateDriverCommands, Driver>
{
    private readonly IApplicationDbContext _context;

    public CreateDriverCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Driver> Handle(CreateDriverCommands request, CancellationToken cancellationToken)
    {
        var entity = new Driver
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Age = request.Age,
        };

        // entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
