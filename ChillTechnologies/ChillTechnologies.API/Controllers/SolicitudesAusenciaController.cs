using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.SolicitudesAusencia.Commands;
using ChillTechnologies.Application.UseCases.SolicitudesAusencia.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitudesAusenciaController : ControllerBase
{
    private readonly IMediator _mediator;

    public SolicitudesAusenciaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllSolicitudesAusenciaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetSolicitudAusenciaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSolicitudAusenciaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSolicitudAusenciaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteSolicitudAusenciaCommand(id)));
}
