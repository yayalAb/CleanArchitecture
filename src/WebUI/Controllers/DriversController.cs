using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Deriver.Commands.Create;
using CleanArchitecture.Application.Deriver.Commands.Delete;
using CleanArchitecture.Application.Deriver.Commands.Update;
using CleanArchitecture.Application.Deriver.Queries.GetDrivers;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

//[Authorize]
public class DriversController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DriverVm>> Get()
    {
        return await Mediator.Send(new GetDriversQuery());
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> CreateDriver(CreateDriverCommands command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, UpdateDriverCommands command)
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
        await Mediator.Send(new DeleteDriverCommands(id));

        return NoContent();
    }
}
