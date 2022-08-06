using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Deriver.Commands.Create;

public class CreateDriverValidators : AbstractValidator<CreateDriverCommands>
{
    private readonly IApplicationDbContext _context;

    public CreateDriverValidators(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name not exceed 200 characters.");
         

        RuleFor(v => v.Phone)
           .NotEmpty().WithMessage("Phone is required.")
           .MaximumLength(14).WithMessage("Phone not exceed 14 characters.").WithMessage("Content Must Be greter Then Zero.")
            .MustAsync(BeUniqueNumber).WithMessage("The specified Phone Number already exists.");
    }

    public async Task<bool> BeUniqueNumber(string phone, CancellationToken cancellationToken)
    {
        return await _context.Drivers
            .AllAsync(l => l.Phone != phone, cancellationToken);
    }
}
