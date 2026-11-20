using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.HistoriasUsuario.Commands;
using ChillTechnologies.Application.UseCases.HistoriasUsuario.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoriasUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public HistoriasUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllHistoriasUsuarioQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetHistoriaUsuarioByIdQuery(id)));

    [HttpGet("sprint/{sprintId:int}")]
    public async Task<IActionResult> GetBySprint(int sprintId)
        => Ok(await _mediator.Send(new GetHistoriasBySprintQuery(sprintId)));

    [HttpGet("backlog/{proyectoId:int}")]
    public async Task<IActionResult> GetBacklog(int proyectoId)
        => Ok(await _mediator.Send(new GetBacklogByProyectoQuery(proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHistoriaUsuarioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateHistoriaUsuarioCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpPatch("{id:int}/sprint")]
    public async Task<IActionResult> MoverSprint(int id, [FromBody] MoverHistoriaSprintCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteHistoriaUsuarioCommand(id)));
}
