using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ProductItem.Commands.Delete;
using CleanArchitecture.Application.ProductItem.Commands.Update;
using CleanArchitecture.Application.ProductItem.Queries.GetProducts;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

//[Authorize]
public class ProductController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ProductVm>> Get()
    {
        return await Mediator.Send(new GetProductsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProducts(CreateProductItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, UpdateProductCommand command)
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
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
