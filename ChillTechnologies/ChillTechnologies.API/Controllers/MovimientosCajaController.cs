using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.MovimientosCaja.Commands;
using ChillTechnologies.Application.UseCases.MovimientosCaja.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosCajaController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovimientosCajaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllMovimientosCajaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetMovimientoCajaByIdQuery(id)));

    [HttpGet("caja/{cajaId:int}")]
    public async Task<IActionResult> GetByCaja(int cajaId)
        => Ok(await _mediator.Send(new GetMovimientosCajaByCajaQuery(cajaId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovimientoCajaCommand command)
        => Ok(await _mediator.Send(command));
}
