using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.ZonasRiesgo.Commands;
using ChillTechnologies.Application.UseCases.ZonasRiesgo.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ZonasRiesgoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ZonasRiesgoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllZonasRiesgoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetZonaRiesgoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateZonaRiesgoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateZonaRiesgoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteZonaRiesgoCommand(id)));
}
