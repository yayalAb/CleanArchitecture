using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Product
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
