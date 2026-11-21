using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.EjecucionesPrueba.Commands;
using ChillTechnologies.Application.UseCases.EjecucionesPrueba.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EjecucionesPruebaController : ControllerBase
{
    private readonly IMediator _mediator;

    public EjecucionesPruebaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllEjecucionesPruebaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetEjecucionPruebaByIdQuery(id)));

    [HttpGet("caso/{casoPruebaId:int}")]
    public async Task<IActionResult> GetByCaso(int casoPruebaId)
        => Ok(await _mediator.Send(new GetEjecucionesByCasoQuery(casoPruebaId)));

    [HttpGet("version/{versionId:int}")]
    public async Task<IActionResult> GetByVersion(int versionId)
        => Ok(await _mediator.Send(new GetEjecucionesByVersionQuery(versionId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEjecucionPruebaCommand command)
        => Ok(await _mediator.Send(command));
}
