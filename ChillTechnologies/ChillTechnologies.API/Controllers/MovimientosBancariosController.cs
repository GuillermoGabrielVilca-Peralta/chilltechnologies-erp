using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.MovimientosBancarios.Commands;
using ChillTechnologies.Application.UseCases.MovimientosBancarios.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosBancariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovimientosBancariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllMovimientosBancariosQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetMovimientoBancarioByIdQuery(id)));

    [HttpGet("cuenta/{cuentaBancariaId:int}")]
    public async Task<IActionResult> GetByCuenta(int cuentaBancariaId)
        => Ok(await _mediator.Send(new GetMovimientosBancariosByCuentaQuery(cuentaBancariaId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovimientoBancarioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPatch("{id:int}/conciliacion")]
    public async Task<IActionResult> Conciliar(int id, [FromBody] ConciliarMovimientoBancarioCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));
}
