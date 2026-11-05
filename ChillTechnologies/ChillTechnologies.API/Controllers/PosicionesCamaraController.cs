using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.PosicionesCamara.Commands;
using ChillTechnologies.Application.UseCases.PosicionesCamara.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PosicionesCamaraController : ControllerBase
{
    private readonly IMediator _mediator;

    public PosicionesCamaraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllPosicionesCamaraQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetPosicionCamaraByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePosicionCamaraCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePosicionCamaraCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeletePosicionCamaraCommand(id)));
}
