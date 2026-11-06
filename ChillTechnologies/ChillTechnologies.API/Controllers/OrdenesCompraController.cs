using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.OrdenesCompra.Commands;
using ChillTechnologies.Application.UseCases.OrdenesCompra.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesCompraController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdenesCompraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllOrdenesCompraQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetOrdenCompraByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdenCompraCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrdenCompraCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteOrdenCompraCommand(id)));
}
