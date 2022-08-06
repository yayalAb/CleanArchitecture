using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Orders.Queries.GetOrders;

//[Authorize]
public record GetOrdersQuery : IRequest<OrdersVm>;
public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrdersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<OrdersVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return new OrdersVm
        {
            Lists = await _context.Orders
                .AsNoTracking()
                .ProjectTo<OrdersDto>(_mapper.ConfigurationProvider)
                .OrderBy(N => N.driverId)
                .ToListAsync(cancellationToken)
        };
    }
}

