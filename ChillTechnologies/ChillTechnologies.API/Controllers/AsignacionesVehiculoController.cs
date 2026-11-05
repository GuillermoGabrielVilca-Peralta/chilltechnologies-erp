using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Commands;
using ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsignacionesVehiculoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AsignacionesVehiculoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllAsignacionesVehiculoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetAsignacionVehiculoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAsignacionVehiculoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAsignacionVehiculoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteAsignacionVehiculoCommand(id)));
}
