using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.SeguimientosTicket.Commands;
using ChillTechnologies.Application.UseCases.SeguimientosTicket.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeguimientosTicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeguimientosTicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetSeguimientoTicketByIdQuery(id)));

    [HttpGet("ticket/{ticketId:int}")]
    public async Task<IActionResult> GetByTicket(int ticketId)
        => Ok(await _mediator.Send(new GetSeguimientosByTicketQuery(ticketId)));

    [HttpGet("ticket/{ticketId:int}/visibles")]
    public async Task<IActionResult> GetVisibles(int ticketId)
        => Ok(await _mediator.Send(new GetSeguimientosVisiblesByTicketQuery(ticketId)));

    [HttpGet("ticket/{ticketId:int}/horas")]
    public async Task<IActionResult> GetHoras(int ticketId)
        => Ok(await _mediator.Send(new GetHorasInvertidasByTicketQuery(ticketId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSeguimientoTicketCommand command)
        => Ok(await _mediator.Send(command));
}
