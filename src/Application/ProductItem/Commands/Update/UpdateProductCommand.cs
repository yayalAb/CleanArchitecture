using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.ProductItem.Commands.Update;

public record UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public String ProductName { get; set; } = string.Empty;
    public String ProductCategory { get; set; } = string.Empty;

    public String ProductQuality { get; set; } = string.Empty;

    public DateTime ProductionDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public int Content { get; set; }

    public Double UnitPrice { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.ProductName = request.ProductName;
        entity.ProductCategory = request.ProductCategory;
        entity.ProductQuality = request.ProductQuality;
        entity.ProductionDate = request.ProductionDate;
        entity.ExpireDate = request.ExpireDate;
        entity.Content = request.Content;
        entity.UnitPrice = request.UnitPrice;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
