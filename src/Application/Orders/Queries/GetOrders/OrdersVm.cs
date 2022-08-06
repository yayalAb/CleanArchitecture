using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.Queries.GetOrders;
public class OrdersVm
{
    public IList<OrdersDto> Lists { get; set; } = new List<OrdersDto>();
}
