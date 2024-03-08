using DotNetBoilerplate.Application.Commands.Tickets.Create;
using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Application.Queries.Tickets;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Exceptions.Errors;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetBoilerplate.Api.Controllers.Tickets;

[Route("tickets")]
[Authorize]
public class TicketsController(
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Creates ticket")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post()
    {
        var command = new CreateTicket();
        await commandDispatcher.DispatchAsync(command);

        return Ok();
    }


    [HttpGet]
    [SwaggerOperation("Browses tickets")]
    [ProducesResponseType(typeof(IEnumerable<TicketDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TicketDto>>> Get()
    {
        var query = new BrowseTickets();
        var tickets = await queryDispatcher.QueryAsync(query);

        return Ok(tickets);
    }
}