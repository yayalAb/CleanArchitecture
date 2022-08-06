using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ProductItem.Queries.GetProducts;
public class ProductDto : IMapFrom<Product>
{
    public String ProductName { get; set; } = string.Empty;
    public String ProductCategory { get; set; } = string.Empty;

    public String ProductQuality { get; set; } = string.Empty;

    public DateTime ProductionDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public int Content { get; set; }

    public Double UnitPrice { get; set; }
}
