using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.TicketsSoporte.Commands;
using ChillTechnologies.Application.UseCases.TicketsSoporte.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsSoporteController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsSoporteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTicketsSoporteQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTicketSoporteByIdQuery(id)));

    [HttpGet("cliente/{clienteId:int}")]
    public async Task<IActionResult> GetByCliente(int clienteId)
        => Ok(await _mediator.Send(new GetTicketsByClienteQuery(clienteId)));

    [HttpGet("pendientes")]
    public async Task<IActionResult> GetPendientes()
        => Ok(await _mediator.Send(new GetTicketsPendientesQuery()));

    [HttpGet("fuera-de-sla")]
    public async Task<IActionResult> GetFueraDeSla()
        => Ok(await _mediator.Send(new GetTicketsFueraDeSlaQuery()));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketSoporteCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTicketSoporteCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpPatch("{id:int}/asignacion")]
    public async Task<IActionResult> Asignar(int id, [FromBody] AsignarTicketSoporteCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));
}
