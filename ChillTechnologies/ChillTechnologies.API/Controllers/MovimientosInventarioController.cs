using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.MovimientosInventario.Commands;
using ChillTechnologies.Application.UseCases.MovimientosInventario.Queries;

namespace ChillTechnologies.API.Controllers;

// un movimiento registrado no se edita ni se borra.
// Para corregir se registra un ajuste en sentido contrario.
[ApiController]
[Route("api/[controller]")]
public class MovimientosInventarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovimientosInventarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllMovimientosInventarioQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetMovimientoInventarioByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovimientoInventarioCommand command)
        => Ok(await _mediator.Send(command));
}
