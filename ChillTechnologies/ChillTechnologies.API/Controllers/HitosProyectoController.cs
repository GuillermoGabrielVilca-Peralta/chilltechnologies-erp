using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.HitosProyecto.Commands;
using ChillTechnologies.Application.UseCases.HitosProyecto.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HitosProyectoController : ControllerBase
{
    private readonly IMediator _mediator;

    public HitosProyectoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllHitosProyectoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetHitoProyectoByIdQuery(id)));

    [HttpGet("proyecto/{proyectoId:int}")]
    public async Task<IActionResult> GetByProyecto(int proyectoId)
        => Ok(await _mediator.Send(new GetHitosByProyectoQuery(proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHitoProyectoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateHitoProyectoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteHitoProyectoCommand(id)));
}
