using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.TiposMantenimiento.Commands;
using ChillTechnologies.Application.UseCases.TiposMantenimiento.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiposMantenimientoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TiposMantenimientoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTiposMantenimientoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTipoMantenimientoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTipoMantenimientoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTipoMantenimientoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTipoMantenimientoCommand(id)));
}
