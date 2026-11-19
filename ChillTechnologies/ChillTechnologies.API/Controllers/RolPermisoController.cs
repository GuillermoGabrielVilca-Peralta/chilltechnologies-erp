using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.RolPermiso.Commands;
using ChillTechnologies.Application.UseCases.RolPermiso.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolPermisoController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolPermisoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllRolPermisoQuery()));

    [HttpGet("rol/{rolId:int}")]
    public async Task<IActionResult> GetByRol(int rolId)
        => Ok(await _mediator.Send(new GetPermisosByRolQuery(rolId)));

    [HttpPost]
    public async Task<IActionResult> Asignar([FromBody] AsignarPermisoRolCommand command)
        => Ok(await _mediator.Send(command));

    [HttpDelete("rol/{rolId:int}/permiso/{permisoId:int}")]
    public async Task<IActionResult> Quitar(int rolId, int permisoId)
        => Ok(await _mediator.Send(new QuitarPermisoRolCommand(rolId, permisoId)));
}
