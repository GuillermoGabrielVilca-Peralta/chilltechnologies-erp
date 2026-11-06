using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DetalleCotizacion.Commands;
using ChillTechnologies.Application.UseCases.DetalleCotizacion.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleCotizacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetalleCotizacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDetalleCotizacionQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDetalleCotizacionByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetalleCotizacionCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetalleCotizacionCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDetalleCotizacionCommand(id)));
}
