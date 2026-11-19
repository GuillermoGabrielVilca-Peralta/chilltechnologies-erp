using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.EquiposProyecto.Commands;
using ChillTechnologies.Application.UseCases.EquiposProyecto.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquiposProyectoController : ControllerBase
{
    private readonly IMediator _mediator;

    public EquiposProyectoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllEquiposProyectoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetEquipoProyectoByIdQuery(id)));

    [HttpGet("proyecto/{proyectoId:int}")]
    public async Task<IActionResult> GetByProyecto(int proyectoId)
        => Ok(await _mediator.Send(new GetEquipoByProyectoQuery(proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEquipoProyectoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEquipoProyectoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteEquipoProyectoCommand(id)));
}
