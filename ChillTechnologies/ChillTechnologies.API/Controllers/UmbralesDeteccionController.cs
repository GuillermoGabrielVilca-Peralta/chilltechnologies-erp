using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.UmbralesDeteccion.Commands;
using ChillTechnologies.Application.UseCases.UmbralesDeteccion.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UmbralesDeteccionController : ControllerBase
{
    private readonly IMediator _mediator;

    public UmbralesDeteccionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUmbralesDeteccionQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetUmbralDeteccionByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUmbralDeteccionCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUmbralDeteccionCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteUmbralDeteccionCommand(id)));
}
