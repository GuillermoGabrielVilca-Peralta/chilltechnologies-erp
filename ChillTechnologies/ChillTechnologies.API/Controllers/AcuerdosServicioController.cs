using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.AcuerdosServicio.Commands;
using ChillTechnologies.Application.UseCases.AcuerdosServicio.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AcuerdosServicioController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcuerdosServicioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllAcuerdosServicioQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetAcuerdoServicioByIdQuery(id)));

    [HttpGet("contrato/{contratoId:int}")]
    public async Task<IActionResult> GetByContrato(int contratoId)
        => Ok(await _mediator.Send(new GetAcuerdosByContratoQuery(contratoId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAcuerdoServicioCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAcuerdoServicioCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteAcuerdoServicioCommand(id)));
}
