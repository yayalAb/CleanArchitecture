using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Orders.Queries.GetOrders;
using CleanArchitecture.Application.Orders.Commands.Create;
using CleanArchitecture.Application.ProductItem.Commands.Delete;
using CleanArchitecture.Application.ProductItem.Commands.Update;
using CleanArchitecture.Application.ProductItem.Queries.GetProducts;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Orders.Commands.Delete;
using CleanArchitecture.Application.Orders.Commands.Update;

namespace CleanArchitecture.WebUI.Controllers;

//[Authorize]
public class OrdersController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<OrdersVm>> Get()
    {
        return await Mediator.Send(new GetOrdersQuery());
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(CreateOrdersCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, UpdateOrdersCommand command)
    {
        if (Id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

 

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}

