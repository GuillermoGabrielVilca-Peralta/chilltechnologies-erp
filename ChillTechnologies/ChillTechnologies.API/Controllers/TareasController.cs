using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Tareas.Commands;
using ChillTechnologies.Application.UseCases.Tareas.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly IMediator _mediator;

    public TareasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTareasQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTareaByIdQuery(id)));

    [HttpGet("historia/{historiaId:int}")]
    public async Task<IActionResult> GetByHistoria(int historiaId)
        => Ok(await _mediator.Send(new GetTareasByHistoriaQuery(historiaId)));

    [HttpGet("empleado/{empleadoId:int}")]
    public async Task<IActionResult> GetByEmpleado(int empleadoId)
        => Ok(await _mediator.Send(new GetTareasByEmpleadoQuery(empleadoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTareaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTareaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTareaCommand(id)));
}
