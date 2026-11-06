using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DetallePedido.Commands;
using ChillTechnologies.Application.UseCases.DetallePedido.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetallePedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetallePedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDetallePedidoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDetallePedidoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetallePedidoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetallePedidoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDetallePedidoCommand(id)));
}
