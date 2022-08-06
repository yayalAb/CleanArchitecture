using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.ProductItem.Commands.CreateProduct;

public record CreateProductItemCommand : IRequest<Product>
{
    public String ProductName { get; set; } = string.Empty;
    public String ProductCategory { get; set; } = string.Empty;

    public String ProductQuality { get; set; } = string.Empty;

    public DateTime ProductionDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public int Content { get; set; }

    public Double UnitPrice { get; set; }
}

public class CreateProductItemCommandHandler : IRequestHandler<CreateProductItemCommand, Product>
{
    private readonly IApplicationDbContext _context;

    public CreateProductItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            ProductName = request.ProductName,
            ProductCategory= request.ProductCategory,
            ProductQuality=request.ProductQuality,
            ProductionDate=request.ProductionDate,
            ExpireDate=request.ExpireDate,
            Content=request.Content,
            UnitPrice=request.UnitPrice
        };

       // entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
