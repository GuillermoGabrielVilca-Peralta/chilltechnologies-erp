using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DetalleFactura.Commands;
using ChillTechnologies.Application.UseCases.DetalleFactura.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleFacturaController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetalleFacturaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDetalleFacturaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDetalleFacturaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetalleFacturaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetalleFacturaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDetalleFacturaCommand(id)));
}
