using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Proyectos.Commands;
using ChillTechnologies.Application.UseCases.Proyectos.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProyectosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllProyectosQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetProyectoByIdQuery(id)));

    [HttpGet("contrato/{contratoId:int}")]
    public async Task<IActionResult> GetByContrato(int contratoId)
        => Ok(await _mediator.Send(new GetProyectosByContratoQuery(contratoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProyectoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProyectoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteProyectoCommand(id)));
}
