using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Auditoria.Commands;
using ChillTechnologies.Application.UseCases.Auditoria.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditoriaController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuditoriaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllAuditoriaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetAuditoriaByIdQuery(id)));

    [HttpGet("usuario/{usuarioSistemaId:int}")]
    public async Task<IActionResult> GetByUsuario(int usuarioSistemaId)
        => Ok(await _mediator.Send(new GetAuditoriaByUsuarioQuery(usuarioSistemaId)));

    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] RegistrarAuditoriaCommand command)
        => Ok(await _mediator.Send(command));
}
