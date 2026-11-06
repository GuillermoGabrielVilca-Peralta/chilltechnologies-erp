using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DetalleAsiento.Commands;
using ChillTechnologies.Application.UseCases.DetalleAsiento.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleAsientoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetalleAsientoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDetalleAsientoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDetalleAsientoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetalleAsientoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetalleAsientoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDetalleAsientoCommand(id)));
}
