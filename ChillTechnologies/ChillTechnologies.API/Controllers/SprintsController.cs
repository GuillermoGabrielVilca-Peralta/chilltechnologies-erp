using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Sprints.Commands;
using ChillTechnologies.Application.UseCases.Sprints.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SprintsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SprintsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllSprintsQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetSprintByIdQuery(id)));

    [HttpGet("proyecto/{proyectoId:int}")]
    public async Task<IActionResult> GetByProyecto(int proyectoId)
        => Ok(await _mediator.Send(new GetSprintsByProyectoQuery(proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSprintCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSprintCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteSprintCommand(id)));
}
