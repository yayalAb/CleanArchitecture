using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ProductItem.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.ProductName)
            .NotEmpty().WithMessage("Product Name is required.")
            .MaximumLength(200).WithMessage("Product Name not exceed 200 characters.")
            .MustAsync(BeUniqueName).WithMessage("The specified Product Name already exists.");

        RuleFor(v => v.Content)
           .NotEmpty().WithMessage("Product Name is required.").LessThan(0)
           .WithMessage("Content Must Be greter Then Zero.");
    }

    public async Task<bool> BeUniqueName(string ProductName, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AllAsync(l => l.ProductName != ProductName, cancellationToken);
    }
}
