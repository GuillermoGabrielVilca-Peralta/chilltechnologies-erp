using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Commands;
using ChillTechnologies.Application.UseCases.DetalleOrdenCompra.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleOrdenCompraController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetalleOrdenCompraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDetalleOrdenCompraQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDetalleOrdenCompraByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetalleOrdenCompraCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetalleOrdenCompraCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDetalleOrdenCompraCommand(id)));
}
