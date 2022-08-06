
namespace CleanArchitecture.Application.ProductItem.Queries.GetProducts;

public class ProductVm
{
    public IList<ProductDto> Lists { get; set; } = new List<ProductDto>();
}