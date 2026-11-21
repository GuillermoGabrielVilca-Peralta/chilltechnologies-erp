using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.CasosPrueba.Commands;
using ChillTechnologies.Application.UseCases.CasosPrueba.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CasosPruebaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CasosPruebaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCasosPruebaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetCasoPruebaByIdQuery(id)));

    [HttpGet("historia/{historiaId:int}")]
    public async Task<IActionResult> GetByHistoria(int historiaId)
        => Ok(await _mediator.Send(new GetCasosByHistoriaQuery(historiaId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCasoPruebaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCasoPruebaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteCasoPruebaCommand(id)));
}
