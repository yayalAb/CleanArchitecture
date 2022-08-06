using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Vechile
{
    public int Id { get; set; }
    public String VechileOwner { get; set; } = String.Empty;
    public String VechileDriver { get; set; } = String.Empty;
    public String VechileType { get; set; } = String.Empty;
    public String VechileModel { get; set; }
}
