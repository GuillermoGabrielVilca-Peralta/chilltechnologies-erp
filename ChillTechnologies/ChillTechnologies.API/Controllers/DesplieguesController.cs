using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Despliegues.Commands;
using ChillTechnologies.Application.UseCases.Despliegues.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesplieguesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DesplieguesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDesplieguesQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDespliegueByIdQuery(id)));

    [HttpGet("version/{versionId:int}")]
    public async Task<IActionResult> GetByVersion(int versionId)
        => Ok(await _mediator.Send(new GetDesplieguesByVersionQuery(versionId)));

    [HttpGet("ambiente/{ambienteId:int}")]
    public async Task<IActionResult> GetByAmbiente(int ambienteId)
        => Ok(await _mediator.Send(new GetDesplieguesByAmbienteQuery(ambienteId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDespliegueCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPatch("{id:int}/cierre")]
    public async Task<IActionResult> Cerrar(int id, [FromBody] CerrarDespliegueCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));
}
