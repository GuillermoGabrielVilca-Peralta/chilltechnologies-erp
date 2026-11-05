using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.TiposNotificacion.Commands;
using ChillTechnologies.Application.UseCases.TiposNotificacion.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiposNotificacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TiposNotificacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTiposNotificacionQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTipoNotificacionByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTipoNotificacionCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTipoNotificacionCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTipoNotificacionCommand(id)));
}
