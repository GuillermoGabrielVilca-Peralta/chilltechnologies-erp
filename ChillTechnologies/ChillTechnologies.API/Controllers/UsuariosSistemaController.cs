using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.UsuariosSistema.Commands;
using ChillTechnologies.Application.UseCases.UsuariosSistema.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosSistemaController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosSistemaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUsuariosSistemaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetUsuarioSistemaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioSistemaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioSistemaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpPatch("{id:int}/password")]
    public async Task<IActionResult> CambiarPassword(int id, [FromBody] CambiarPasswordUsuarioSistemaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteUsuarioSistemaCommand(id)));
}
