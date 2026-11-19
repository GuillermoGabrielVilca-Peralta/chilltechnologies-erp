using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.ParametrosSistema.Commands;
using ChillTechnologies.Application.UseCases.ParametrosSistema.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParametrosSistemaController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParametrosSistemaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllParametrosSistemaQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetParametroSistemaByIdQuery(id)));

    [HttpGet("clave/{clave}")]
    public async Task<IActionResult> GetByClave(string clave)
        => Ok(await _mediator.Send(new GetParametroSistemaByClaveQuery(clave)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParametroSistemaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateParametroSistemaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteParametroSistemaCommand(id)));
}
