using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ProductItem.Queries.GetProducts;

//[Authorize]
public record GetProductsQuery : IRequest<ProductVm>;
public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProductVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return new ProductVm
        {        Lists = await _context.Products
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(N => N.ProductName)
                .ToListAsync(cancellationToken)
        };
    }
}











//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Mappings;
//using CleanArchitecture.Application.Common.Models;
//using MediatR;

//namespace CleanArchitecture.Application.ProductItem.Queries.GetProducts;

//public record GetProducts : IRequest<PaginatedList<ProductDto>>
//{
//    public int ProductId { get; init; }
//    public int PageNumber { get; init; } = 1;
//    public int PageSize { get; init; } = 10;
//}

//public class GetProductsQueryHandler : IRequestHandler<GetProducts, PaginatedList<ProductDto>>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    public async Task<PaginatedList<ProductDto>> Handle(GetProducts request, CancellationToken cancellationToken)
//    {
//        return await _context.Products
//            .OrderBy(x => x.Name)
//            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
//            .PaginatedListAsync(request.PageNumber, request.PageSize);
//    }
//}
