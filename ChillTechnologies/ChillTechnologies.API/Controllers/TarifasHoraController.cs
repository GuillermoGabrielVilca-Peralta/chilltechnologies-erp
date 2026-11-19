using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.TarifasHora.Commands;
using ChillTechnologies.Application.UseCases.TarifasHora.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarifasHoraController : ControllerBase
{
    private readonly IMediator _mediator;

    public TarifasHoraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllTarifasHoraQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetTarifaHoraByIdQuery(id)));

    [HttpGet("vigente")]
    public async Task<IActionResult> GetVigente([FromQuery] int cargoId, [FromQuery] int? proyectoId)
        => Ok(await _mediator.Send(new GetTarifaVigenteQuery(cargoId, proyectoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTarifaHoraCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTarifaHoraCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTarifaHoraCommand(id)));
}
