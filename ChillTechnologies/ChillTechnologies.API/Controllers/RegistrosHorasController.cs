using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.RegistrosHoras.Commands;
using ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrosHorasController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrosHorasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllRegistrosHorasQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetRegistroHoraByIdQuery(id)));

    [HttpGet("proyecto/{proyectoId:int}")]
    public async Task<IActionResult> GetByProyecto(int proyectoId)
        => Ok(await _mediator.Send(new GetHorasByProyectoQuery(proyectoId)));

    [HttpGet("empleado/{empleadoId:int}")]
    public async Task<IActionResult> GetByEmpleado(int empleadoId, [FromQuery] DateOnly desde, [FromQuery] DateOnly hasta)
        => Ok(await _mediator.Send(new GetHorasByEmpleadoQuery(empleadoId, desde, hasta)));

    [HttpGet("proyecto/{proyectoId:int}/facturables")]
    public async Task<IActionResult> GetFacturables(int proyectoId)
        => Ok(await _mediator.Send(new GetHorasFacturablesByProyectoQuery(proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegistroHoraCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPatch("{id:int}/aprobacion")]
    public async Task<IActionResult> Aprobar(int id, [FromBody] AprobarRegistroHoraCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));
}
