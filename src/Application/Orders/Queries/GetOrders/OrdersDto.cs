using System;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Application.Orders.Queries.GetOrders;
public class OrdersDto:IMapFrom<Order>
{
    public int Id { get; set; }
    public String OrderedBy { get; set; } = String.Empty;
    public String driverId { get; set; }
    public String Start { get; set; } = String.Empty;
    public String Destination { get; set; } = String.Empty;
    public Boolean status { get; set; } = false;
}
