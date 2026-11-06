using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.CuentasPorPagar.Commands;
using ChillTechnologies.Application.UseCases.CuentasPorPagar.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentasPorPagarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuentasPorPagarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCuentasPorPagarQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetCuentaPorPagarByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCuentaPorPagarCommand command)
        => Ok(await _mediator.Send(command));

    // Registra un abono: descuenta del saldo y recalcula el estado
    [HttpPut("{id:int}/abono")]
    public async Task<IActionResult> RegistrarAbono(int id, [FromBody] UpdateCuentaPorPagarCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteCuentaPorPagarCommand(id)));
}
