using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.ContratosDesarrollo.Commands;
using ChillTechnologies.Application.UseCases.ContratosDesarrollo.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratosDesarrolloController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContratosDesarrolloController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllContratosDesarrolloQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetContratoDesarrolloByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContratoDesarrolloCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateContratoDesarrolloCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteContratoDesarrolloCommand(id)));
}
