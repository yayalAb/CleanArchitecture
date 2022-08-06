using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class OrderList
{
    public int Id { get; set; }
    public Order order { get; set; }
    public Product Product { get; set; }
    public int quantity { get; set; }
    public double price { get; set; }
}
