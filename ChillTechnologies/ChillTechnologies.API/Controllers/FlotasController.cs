using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Flotas.Commands;
using ChillTechnologies.Application.UseCases.Flotas.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlotasController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlotasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllFlotasQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetFlotaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFlotaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateFlotaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteFlotaCommand(id)));
}
