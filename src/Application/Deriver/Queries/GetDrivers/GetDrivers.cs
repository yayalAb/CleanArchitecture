using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Deriver.Queries.GetDrivers;

//[Authorize]
public record GetDriversQuery : IRequest<DriverVm>;
public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, DriverVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDriversQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DriverVm> Handle(GetDriversQuery request, CancellationToken cancellationToken)
    {
        return new DriverVm
        {
            Lists = await _context.Drivers
                .AsNoTracking()
                .ProjectTo<DriverDto>(_mapper.ConfigurationProvider)
                .OrderBy(N => N.Name)
                .ToListAsync(cancellationToken)
        };
    }
}

