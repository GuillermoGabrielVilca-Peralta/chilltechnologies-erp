using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.MovimientosPuntos.Commands;
using ChillTechnologies.Application.UseCases.MovimientosPuntos.Queries;

namespace ChillTechnologies.API.Controllers;

// Libro mayor inmutable: una vez registrado un movimiento no se edita ni se borra
[ApiController]
[Route("api/[controller]")]
public class MovimientosPuntosController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovimientosPuntosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllMovimientosPuntosQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetMovimientoPuntoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovimientoPuntoCommand command)
        => Ok(await _mediator.Send(command));
}
