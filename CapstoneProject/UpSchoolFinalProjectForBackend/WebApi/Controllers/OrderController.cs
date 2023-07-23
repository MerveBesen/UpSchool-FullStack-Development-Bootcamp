using Application.Features.Orders.Commands.Add;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class OrderController : ApiControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync(OrderAddCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}