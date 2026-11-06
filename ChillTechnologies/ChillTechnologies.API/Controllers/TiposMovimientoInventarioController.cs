using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Commands;
using ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiposMovimientoInventarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public TiposMovimientoInventarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTiposMovimientoInventarioQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTipoMovimientoInventarioByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTipoMovimientoInventarioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTipoMovimientoInventarioCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTipoMovimientoInventarioCommand(id)));
}
