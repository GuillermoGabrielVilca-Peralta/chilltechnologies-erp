using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.EmisionesViaje.Commands;
using ChillTechnologies.Application.UseCases.EmisionesViaje.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmisionesViajeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmisionesViajeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllEmisionesViajeQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetEmisionViajeByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmisionViajeCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmisionViajeCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteEmisionViajeCommand(id)));
}
