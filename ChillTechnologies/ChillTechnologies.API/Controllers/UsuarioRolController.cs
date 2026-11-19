using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.UsuarioRol.Commands;
using ChillTechnologies.Application.UseCases.UsuarioRol.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioRolController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioRolController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUsuarioRolQuery()));

    [HttpGet("usuario/{usuarioSistemaId:int}")]
    public async Task<IActionResult> GetByUsuario(int usuarioSistemaId)
        => Ok(await _mediator.Send(new GetRolesByUsuarioQuery(usuarioSistemaId)));

    [HttpPost]
    public async Task<IActionResult> Asignar([FromBody] AsignarRolUsuarioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpDelete("usuario/{usuarioSistemaId:int}/rol/{rolId:int}")]
    public async Task<IActionResult> Quitar(int usuarioSistemaId, int rolId)
        => Ok(await _mediator.Send(new QuitarRolUsuarioCommand(usuarioSistemaId, rolId)));
}
