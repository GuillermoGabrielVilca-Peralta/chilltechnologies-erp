using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.CuentasPorCobrar.Commands;
using ChillTechnologies.Application.UseCases.CuentasPorCobrar.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentasPorCobrarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuentasPorCobrarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCuentasPorCobrarQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetCuentaPorCobrarByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCuentaPorCobrarCommand command)
        => Ok(await _mediator.Send(command));

    // elcobro, descuenta del saldo y recalcula el estado
    [HttpPut("{id:int}/cobro")]
    public async Task<IActionResult> RegistrarCobro(int id, [FromBody] UpdateCuentaPorCobrarCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteCuentaPorCobrarCommand(id)));
}
