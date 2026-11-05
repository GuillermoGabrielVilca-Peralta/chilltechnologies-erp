using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.PuntosUsuarios.Commands;
using ChillTechnologies.Application.UseCases.PuntosUsuarios.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PuntosUsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PuntosUsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllPuntosUsuariosQuery()));

    [HttpGet("{usuarioId:int}")]
    public async Task<IActionResult> GetById(int usuarioId)
        => Ok(await _mediator.Send(new GetPuntosUsuarioByIdQuery(usuarioId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePuntosUsuarioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{usuarioId:int}")]
    public async Task<IActionResult> Update(int usuarioId, [FromBody] UpdatePuntosUsuarioCommand command)
        => Ok(await _mediator.Send(command with { UsuarioId = usuarioId }));

    [HttpDelete("{usuarioId:int}")]
    public async Task<IActionResult> Delete(int usuarioId)
        => Ok(await _mediator.Send(new DeletePuntosUsuarioCommand(usuarioId)));
}
