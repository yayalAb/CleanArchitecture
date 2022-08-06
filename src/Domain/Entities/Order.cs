using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Order
{
    public int Id { get; set; }
    public String OrderedBy { get; set; } = String.Empty;
    public String driverId { get; set; }
    public String Start { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;
    public Boolean status { get; set; } = false;

}
